using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerMortionController))]
public class PlayerController : MonoBehaviour
{  //プレイヤーのすべてがここにある。　マグロ、撮影開始　

    public float moveForce = 60, SneakMultiplier = 1;
    Rigidbody2D myBody;
    public float PlayerHP = 6;

    public float falseTimer = 0.5f;

    public DM_Effect DMFX;

    public AudioClip DamageSE;
    private AudioSource audioSource;

    private PlayerMortionController m_PlayerA;


    // Use this for initialization
    void Start()
    {

        myBody = this.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();


        m_PlayerA = GetComponent<PlayerMortionController>();
    }





    //動画を参考にしたため全くわからん()　知らない関数多すぎぃ！！
    void FixedUpdate()
    {

        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        bool isSneaking = CrossPlatformInputManager.GetButton("Sneak");
        //Debug.Log(isSneaking ? SneakMultiplier : 1);

        myBody.AddForce(moveVec * (isSneaking ? SneakMultiplier : 1));


        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");


        m_PlayerA.Move(h, v);

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SpiderDMH")
        {
            DMFX.AddEffectON();

            audioSource.PlayOneShot(DamageSE);

            PlayerHP -= 1;


            if (PlayerHP <= 0)
            {
                Application.LoadLevel("GAMEOVER");
            }

            //Debug.Log(PlayerHP);

        }




        
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "GOAL")
        {
            //Debug.Log("Goal");
            moveForce -= 60;
        }



        if (collider.gameObject.tag == "BigSpider")
        {
            // Debug.Log("でゅくし");
            PlayerHP -= 5;


            if (PlayerHP <= 0)
            {
                Application.LoadLevel("GAMEOVER");
            }

        }
    }








}


/*    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "SpiderDMH")
        {
            Debug.Log("強烈な物理的ダメージ");
        }

    }*/
