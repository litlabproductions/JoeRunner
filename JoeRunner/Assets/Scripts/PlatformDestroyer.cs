using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;

    	// ~ Use this for initialization
	void Start ()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	    // ~ Update is called once per frame
	void Update ()
    {

        //platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");

        // ~ If platform behind camera is also far back enough
        //   to have also fallen behind our destructionPoint.
        if (transform.position.x < platformDestructionPoint.transform.position.x)
            gameObject.SetActive(false);
                
                //  Destroy(gameObject);
	}
}
