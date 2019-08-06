using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal_Controller : MonoBehaviour {


    public Image logoImage;
    public float TIMEA = 0;

    public AudioClip CarSE;


    // Use this for initialization
    void Start () {
        Image logoImage = GetComponent<Image>();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = CarSE;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            ClearFadeOut();
           // Debug.Log("クリア");
        }

    }

    public void ClearFadeOut()
    {

        

        TIMEA += 0.01f;

        logoImage.color = new Color(1.0f, 1.0f, 1.0f, TIMEA);

        if(TIMEA <= 1.5f)
        {
            GetComponent<AudioSource>().Play();
        }
       


        if(TIMEA >= 3f)
        {
            Application.LoadLevel("Clear");
        }
    }

}
