using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEND_Controller : MonoBehaviour {


    public GameObject GameEndGUI;
    public AudioClip Clik_SE;
    public AudioClip Clik_SE2;
    public AudioSource audioSource;



    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
    }


    //ボタンを押すとHatuden_ screenを表示する
    public void GMendGuiON()
    {
        audioSource.PlayOneShot(Clik_SE);
        GameEndGUI.SetActive(true);

    }

    //ボタンを押すとHatuden_ screenを非表示にする
    public void GMendGuiOFF()
    {
        audioSource.PlayOneShot(Clik_SE2);
        GameEndGUI.SetActive(false);

    }
}
