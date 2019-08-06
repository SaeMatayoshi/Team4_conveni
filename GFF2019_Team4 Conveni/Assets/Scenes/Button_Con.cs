using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Con : MonoBehaviour {

    public GameObject SentakuGUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackTitle ()
    {
        Application.LoadLevel("Title");
    }

    public void RetryGame()
    {
        Application.LoadLevel("Main");
    }

    public void Sentaku()
    {
        SentakuGUI.SetActive(true);
    }


}
