using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_ButtonCon : MonoBehaviour {  //発電画面をボタンで表示、非表示するスクリプト

    public GameObject hatudenGUI;
    public AudioClip Clik_SE;
    public AudioClip Clik_SE2;
    public AudioSource audioSource;



    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	void Update () {
	}


    //ボタンを押すとHatuden_ screenを表示する
    public void LightGuiON()
    {
        hatudenGUI.SetActive(true);
        audioSource.PlayOneShot(Clik_SE);
        Time.timeScale = 0f;

    }

    //ボタンを押すとHatuden_ screenを非表示にする
    public void LightGuiOFF()
    {
        hatudenGUI.SetActive(false);
        audioSource.PlayOneShot(Clik_SE2);
        Time.timeScale = 1f;

    }
}
