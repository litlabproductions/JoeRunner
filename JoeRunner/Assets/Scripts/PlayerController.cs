using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;



    public float jumpForce;

    // ~ Speed multiplyer.
    public float speedMultiplier;

    public float speedIncreasedMilestone;
    public float speedIncreaseMilestoneStore;

    private float speedMileStoneCount;

    private float speedMilestoneCountStore;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    // ~ Catches all colliders. 
    //   eg. Box, Circle, Poly..
    //private Collider2D myCollider;

    private bool stoppedJumping;
    private bool canDoubleJump;
    bool isShooting;

    public float maxSpeed;

        // ~ Only this script is given rights to
        //   manipulate our players movement.
    private Rigidbody2D myRigidBody;

        // ~ Animator
    private Animator myAnimator;

    public GameManager theGameManager;


    public AudioSource jumpSound;
    public AudioSource deathSound;


    private UIManager theUIManager;


    // ~ Use this for initialization
    // ~ Use calls in start that would otherwise be to taxing 
    //   on efficiency if called every second from update.
    void Start ()
    {    
        myRigidBody = GetComponent <Rigidbody2D>();
       // myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMileStoneCount = speedIncreasedMilestone;

            // ~ Reset move speed
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMileStoneCount;
        speedIncreaseMilestoneStore = speedIncreasedMilestone;

        stoppedJumping = true;


        theUIManager = FindObjectOfType<UIManager>();
    }
	
	    // ~ Update is called once per frame
	void Update ()  
    {
        // ~ Determine if the player is on the ground.
        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // ~ Speed Increase.
        if (transform.position.x > speedMileStoneCount)
        {
            speedMileStoneCount += speedIncreasedMilestone;
            speedIncreasedMilestone = speedIncreasedMilestone * speedMultiplier;
            
            if (moveSpeed < maxSpeed)
                moveSpeed = moveSpeed * speedMultiplier;
        }

        // ~ Constant Velocity.
        if (moveSpeed < maxSpeed)
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        // ~ Jump.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }

            if (!grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
            isShooting = true;

        if (Input.GetKeyUp(KeyCode.Q))
            isShooting = false ;
        
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        // ~ Animator.
        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("isShooting", isShooting);

        theUIManager.setSpeed(myRigidBody.velocity.x);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMileStoneCount = speedMilestoneCountStore;
            speedIncreasedMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();

        }
    }


}
