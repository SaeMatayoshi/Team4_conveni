using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dif : MonoBehaviour {
    GameObject ShotPos;
    GameObject BasePos;

    public Vector2 dif;

    Vector2 targetPos;
    Vector2 basePos;

	// Use this for initialization
	void Start () {
        ShotPos = GameObject.FindGameObjectWithTag("Shot");
        BasePos = GameObject.FindGameObjectWithTag("Player");

        targetPos = ShotPos.transform.position;
        basePos = BasePos.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        dif = targetPos - basePos;
        //Debug.Log(dif);
    }
}
