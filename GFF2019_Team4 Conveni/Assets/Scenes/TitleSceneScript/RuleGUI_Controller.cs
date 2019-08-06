using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleGUI_Controller : MonoBehaviour {
    public GameObject RuleGUI;
    public GameObject Image;

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
    public void LightGuiON()
    {
        audioSource.PlayOneShot(Clik_SE);
        RuleGUI.SetActive(true);
        Image.SetActive(false);

    }

    //ボタンを押すとHatuden_ screenを非表示にする
    public void LightGuiOFF()
    {
        audioSource.PlayOneShot(Clik_SE2);
        RuleGUI.SetActive(false);
        Image.SetActive(true);

    }
}
