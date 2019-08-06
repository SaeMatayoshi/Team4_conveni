using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Item : MonoBehaviour {

    public float ItemSpeed;
    new Rigidbody2D rigidbody2D;

    public Dif Difcs;

    Vector2 dif;

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Difcs = GetComponent<Dif>();
    }	

	// Update is called once per frame
	void Update ()
    {
        dif = Difcs.dif;

        rigidbody2D.velocity = dif * ItemSpeed;

        Destroy(gameObject, 2.0f);
    }
}
