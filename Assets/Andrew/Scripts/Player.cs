using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float walkSpeed = 6f;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    private CharacterController controller; // Reference to character controller
    private Vector3 motion; // Is the movement offset per frame
    private bool isJumping;
    private float currentJumpHeight;
    private float currentSpeed;

    public bool isDoubleJumping;
    public bool canDoubleJump;




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



        if (inputDir.magnitude > 1f)
        {
            // Normalize it to 1f!
            inputDir.Normalize();
        }
        //transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);


        if (inputWalk)
        {
            currentSpeed = walkSpeed;
        }

        Move(inputDir.x, inputDir.z, currentSpeed);


        // If is Grounded
        if (controller.isGrounded)
        {
            canDoubleJump = false;
            isDoubleJumping = false;
        }

        if (controller.isGrounded || canDoubleJump)
        {
            // .. And jump?
            if (inputJump)
            {
                Jump(jumpHeight);
            }

            // Cancel the y velocity

            if (controller.isGrounded)
            {
                motion.y = 0f;
            }


            // Is jumping bool set to true
            if (isJumping)
            {
                // Set jump height
                motion.y = currentJumpHeight;
                // Reset back to false
                isJumping = false;
            }
        }
        if (inputJump && canDoubleJump)
        {
            canDoubleJump = false;

            isDoubleJumping = true;
        }

        if (!controller.isGrounded && !isDoubleJumping)
        {
            canDoubleJump = true;

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
    private void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);
        motion.x = direction.x * speed;
        motion.z = direction.z * speed;
    }


    public void Walk(float inputH, float inputV)
    {
        Move(inputH, inputV, walkSpeed);
    }
    public void Jump(float height)
    {
        isJumping = true; // We are jumping!
        currentJumpHeight = height;
    }
    public void DoubleJump(float height)
    {
        isDoubleJumping = true; // We are jumping!
        currentJumpHeight = height;
    }
}
   