using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSound : MonoBehaviour {

    public AudioSource phoneSound;
    public AudioClip phone;

	// Use this for initialization
	void Start ()
    {
        phoneSound = GetComponent<AudioSource>();
        StartCoroutine("Sound");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    private IEnumerator Sound()
    {
        yield return new WaitForSeconds(5.0f);
        phoneSound.PlayOneShot(phone);
    }
}
