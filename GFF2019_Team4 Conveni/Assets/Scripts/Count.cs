using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {

    private GameObject[] tagObjects;
    private int i = 0;
    private int count;

    public bool Iscount = false;
    //public GameObject scoretxt;
    //public Text scoreText;

    float timer = 0.0f;
    float interval = 1.0f;

    public GameObject BARIA;

	// Use this for initialization
	void Start () {
        //scoreText = scoretxt.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > interval)
        {
            Check("Friend");

            timer = 0;
        }

        //scoreText.text = "nokori : " + tagObjects.Length;
        //Check("Friend");
	}

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        Debug.Log(tagObjects.Length);

        if(tagObjects.Length == 1 && i == 0)
        {
            Iscount = true;
            i = 1;
            //Debug.Log(Iscount);
        }

        if(tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");

            Destroy(BARIA);
        }
    }
}
