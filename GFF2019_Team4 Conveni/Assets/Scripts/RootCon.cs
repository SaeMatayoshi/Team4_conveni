using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCon : MonoBehaviour {　//蜘蛛が感知範囲にプレイヤーが入るとそっちを向く+決められたポイントへまっすぐ向かう　スプリクト



    [SerializeField, Range(0, 100)]
    float time = 1;　//スタートから決められたポイントまでの移動時間

    [SerializeField]
    Vector3 endPosition;

    [SerializeField]
    AnimationCurve curve;

    private float startTime;
    private Vector3 startPosition;
    public Spider SSC;
    
    

    void OnEnable()
    {
        if (time <= 0)
        {
            transform.position = endPosition;
            enabled = false;
            return;

            
        }

        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
    }

    void Start () {

        SSC = GetComponent<Spider>();

        LookEDP();
        


    }
	
	// Update is called once per frame
	void Update () {


        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            transform.position = endPosition;
            enabled = false;
        }

        var rate = diff / time;

        transform.position = Vector3.Lerp(startPosition, endPosition, rate);


        var curvePos = curve.Evaluate(rate);

        transform.position = Vector3.Lerp(startPosition, endPosition, curvePos);

    }



    void OnTriggerStay2D(Collider2D other)　//プレイヤーがコライダー(感知範囲)に入ったかを判断
    {
        if (other.gameObject.tag == "Player")
        {
            enabled = false;
        }
       
    }

    //感知範囲を出るとプレイヤーを諦め、また決められたポイントに向かって進み始める
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enabled = true;
            LookEDP();

            SSC.AniOFF();
        }
    }


    //決めたポイントに向かって進む　　サイトから参考してきた。　　なるほどね完全に理解したわ(全くわかってない)
    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR

        if (!UnityEditor.EditorApplication.isPlaying || enabled == false)
        {
            startPosition = transform.position;
        }
        else
        {
            enabled = true;
        }

        UnityEditor.Handles.Label(endPosition, endPosition.ToString());
        UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
        Gizmos.DrawSphere(endPosition, 0.1f);
        Gizmos.DrawSphere(startPosition, 0.1f);

        Gizmos.DrawLine(startPosition, endPosition);
    }


    //プレイヤーの方を向く
    void LookEDP()
    {
        var vec = (endPosition - this.transform.position).normalized;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);
    }
}
