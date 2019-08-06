using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleFeido : MonoBehaviour {

    public Image logoImage;

    // Use this for initialization
    void Start () {
        Image logoImage = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        float RD = Random.Range(0.4f, 0.45f);
        logoImage.color = new Color(0f, 0f, 0f, RD);
    }
}
