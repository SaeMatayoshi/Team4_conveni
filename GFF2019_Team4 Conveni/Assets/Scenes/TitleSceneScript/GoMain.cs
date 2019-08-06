using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMain : MonoBehaviour {

    public AudioClip Clik_SE;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStartButton()
    {
        audioSource.PlayOneShot(Clik_SE);
        Invoke("GOmain", 0.5f);
    }

    public void GOmain()
    {
        Application.LoadLevel("Main");
    }
}
