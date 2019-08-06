using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusMenuUI_Con : MonoBehaviour {

    public GameObject StatusUI;
    public AudioClip Clik_SE2;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {


    }



    public void LightGuiON()
    {
        StatusUI.SetActive(true);
        audioSource.PlayOneShot(Clik_SE2);
        Time.timeScale = 0f;

    }

    //ボタンを押すとHatuden_ screenを非表示にする
    public void LightGuiOFF()
    {
        StatusUI.SetActive(false);

        Time.timeScale = 1f;

    }

    public void BackTitleScene()
    {
        Application.LoadLevel("Title");
    }
}


