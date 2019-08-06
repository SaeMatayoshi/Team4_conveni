using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;

public class Shot : MonoBehaviour {

    public GameObject ItemPrefab;
    public GameObject Player;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        var v1 = CrossPlatformInputManager.GetAxis("Vertical");
        var h1 = CrossPlatformInputManager.GetAxis("Horizontal");

        if(h1 != 0 || v1 != 0)
        {
            var direction = new Vector3(h1, v1, 0);

            gameObject.transform.position = Player.transform.position + direction;
        }
    }
    
    public void OnShotButtonClick()
    {
        Instantiate(
           ItemPrefab,
           gameObject.transform.position,
           Quaternion.identity
           );
    }

}