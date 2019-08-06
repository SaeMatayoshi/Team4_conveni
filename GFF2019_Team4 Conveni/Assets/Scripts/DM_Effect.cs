using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM_Effect : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEffectON()
    {
        this.gameObject.SetActive(true);

        Invoke("Call", 0.5f);

    }

    void Call()
    {
        this.gameObject.SetActive(false);
    }


}
