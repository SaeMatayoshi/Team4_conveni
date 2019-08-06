using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {　　//クモさんを管理するスクリプト

    public GameObject player;
    public float MoveSpeed2;　//クモさんの移動速度
    Animator anim;

    public AudioClip SpiderBGM;
    


    // Use this for initialization
    void Start () {

        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = SpiderBGM;

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }

    }    

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Stop();
        }
        
    }
    //プレイヤーがコライダー(感知範囲)に入ったら PlayerLook()をする
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("感知圏内にプレイヤーが入りました。");

            anim.Play("Spider_AT");

            

            PlayerLook();

            

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.Translate(0, -2, 0);

            

        }
    }

    //プレイヤーのほうを向く
    void PlayerLook()
    {
        var vec = (player.transform.position - this.transform.position).normalized;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);

        transform.Translate(0, 1 * MoveSpeed2 * Time.deltaTime, 0);

        
    }

    public void AniOFF()
    {
        anim.Play("idol");
    }
    
}
