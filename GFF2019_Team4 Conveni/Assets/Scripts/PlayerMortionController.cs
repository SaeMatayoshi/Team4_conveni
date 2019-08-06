using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMortionController : MonoBehaviour {


    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;


    [SerializeField]


    // Use this for initialization
    void Start () {

        m_Anim = GetComponent<Animator>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(float h_move, float v_move)
    {

        //モーション判定用のパラメータ   
        m_Anim.SetFloat("Direction_X", h_move);
        m_Anim.SetFloat("Direction_Y", v_move);


    }
}
