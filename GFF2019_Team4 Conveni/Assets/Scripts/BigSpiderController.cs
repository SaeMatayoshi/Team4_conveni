using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpiderController : MonoBehaviour　//本ゲーム最強の大グモちゃんの管理するスプリクト
{
    public GameObject player;
    public float MoveSpeed = 1;
    public int count = 150;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

    }

 
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D other)　//プレイヤーがコライダー(感知範囲)に入ったかを判断
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("感知圏内にプレイヤーが入りました。");

            PlayerLook();


            int SPC = Random.Range (0, count );   //ランダム関数で　1/count の確率でspeedUP()します。　たまにプレイヤー絶対殺すマンになる(修正の予定なし)
            if (SPC == 10)
            {
                speedUP();
            }

        }
    }

    void PlayerLook()  //蜘蛛がプレイヤーの方を向いて動く
    {

        var vec = (player.transform.position - this.transform.position).normalized;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);

        transform.Translate(0, 1 * MoveSpeed * Time.deltaTime, 0);

       
      
      
    }

    　//名前の通り　一瞬だけスピードします。　ジャンプしてるみたいで可愛い
    void speedUP() 
    {
        transform.Translate(0, 2 ,0);
    }
}
