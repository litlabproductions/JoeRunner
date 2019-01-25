using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float speed = -1.5f;
   [SerializeField] private bool stopScrolling;


	    // ~ Initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(speed, 0);

    }
	
	    // Update is called once per frame
	void Update ()
    {
        if (stopScrolling)
            rigidBody.velocity = Vector2.zero;
        else
            rigidBody.velocity = new Vector2(speed, 0);
    }
}
