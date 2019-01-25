using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        // ~ Player Obj.
    public PlayerController thePlayer;

        // ~ Pos of player v3(x, y, z).
    private Vector3 lastPlayerPosition;

    private float distanceToMove;

	    // Use this for initialization
	void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
    }
	
	    // Update is called once per frame
	void Update ()
    {       // ~ Find Distance.
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

            // Close gap.
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

            // ~ Sync (lock-on) to player position.
        lastPlayerPosition = thePlayer.transform.position;
	}
}
