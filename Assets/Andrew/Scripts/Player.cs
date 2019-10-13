using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float runSpeed = 8f;
    public float walkSpeed = 6f;
    public float dashSpeed = 20f;
    public float dashTime = 2f;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    public float groundRayDistance = 1.1f;
    private CharacterController controller; // Reference to character controller
    private Vector3 motion; // Is the movement offset per frame
    private bool isJumping;
    private float currentJumpHeight;
    private float currentSpeed;




    // Functions
    #region Respawn Martin's Code
    public Vector3 playerGhost;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            playerGhost = gameObject.transform.position;
            other.gameObject.SetActive(false);
        }
    }
    #endregion
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }
    private void Update()
    {
        // W A S D / Right Left Up Down Arrow Input
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Left Shift Input
        bool inputRun = Input.GetKeyDown(KeyCode.LeftShift);
        bool inputWalk = Input.GetKeyUp(KeyCode.LeftShift);
        // Space Bar Input
        bool inputJump = Input.GetButtonDown("Jump");
        // Put Horizontal & Vertical input into vector
        Vector3 inputDir = new Vector3(inputH, 0f, inputV);
        // Rotate direction to Player's Direction
        inputDir = transform.TransformDirection(inputDir);
        // If input exceeds length of 1

        ControlPlayer();

        if (inputDir.magnitude > 1f)
        {
            // Normalize it to 1f!
            inputDir.Normalize();
        }
        //transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

        // If running
        if (inputRun)
        {
            currentSpeed = runSpeed;
        }

        if (inputWalk)
        {
            currentSpeed = walkSpeed;
        }

        // Move(inputDir.x, inputDir.z, currentSpeed);

        // If is Grounded
        if (controller.isGrounded)
        {
            // .. And jump?
            if (inputJump)
            {
                Jump(jumpHeight);
            }

            // Cancel the y velocity
            motion.y = 0f;

            // Is jumping bool set to true
            if (isJumping)
            {
                // Set jump height
                motion.y = currentJumpHeight;
                // Reset back to false
                isJumping = false;
            }
        }

        motion.y += gravity * Time.deltaTime;
        controller.Move(motion * Time.deltaTime);
    }
    void ControlPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.30F);


        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

    }
    /*private void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);
        motion.x = direction.x * speed;
        motion.z = direction.z * speed;
    }
    IEnumerator SpeedBoost(float startDash, float endDash, float delay)
    {
        currentSpeed = startDash;

        yield return new WaitForSeconds(delay);

        currentSpeed = endDash;
    }
    public void Walk(float inputH, float inputV)
    {
        Move(inputH, inputV, walkSpeed);
    }
    public void Run(float inputH, float inputV)
    {
        Move(inputH, inputV, runSpeed);
    }*/
    public void Jump(float height)
    {
        isJumping = true; // We are jumping!
        currentJumpHeight = height;
    }
    /*public void Dash()
    {
        StartCoroutine(SpeedBoost(dashSpeed, walkSpeed, dashTime));
    }*/

    /*private void UpdatePlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CharacterController.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
        }

        #region Angles
        if (Input.GetKey(KeyCode.W))
        {
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
    }*/
}



/*
using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float groundRayDistance = 1.1f;

    public float jumpHeight = 15f;
    private bool isJumping;
    private float currentJumpHeight;
    public float gravity = -10f;

    public bool canMove = true;
    public bool dead = false;

    private CharacterController controller;
    private Rigidbody rigidBody;
    private Transform myTransform;
    private Vector3 motion;
    private Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    void Update()
    {
        UpdateMovement();

        bool inputJump = Input.GetButtonDown("Jump");
        if (controller.isGrounded)
        {
            if (inputJump)
            {
                Jump(jumpHeight);
            }

            motion.y = 0f;

            if (isJumping)
            {
                motion.y = currentJumpHeight;
                isJumping = false;
            }
        }

        motion.y += gravity * Time.deltaTime;
    }

    private void UpdateMovement()
    {
        if (!canMove)
        {
            return;
        }

        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        { 
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        { 
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.S))
        { 
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        { 
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
        }

        #region Angles
        if (Input.GetKey(KeyCode.W))
        {
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
    }

    public void Jump(float height)
    {
        isJumping = true; 
        currentJumpHeight = height;
    }


   private void UpdatePlayer2Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            Debug.Log("P" + playerNumber + " hit by explosion!");
            dead = true; // 1
            globalManager.PlayerDied(playerNumber); // 2
            Destroy(gameObject); // 3  
        }
    }
    */
