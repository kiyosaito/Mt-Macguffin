using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    public float groundRayDistance = 1.1f;
    private CharacterController controller;
    private Vector3 motion;
    private bool isJumping;


    void Update()
    {
        ControllPlayer();

    }

    public void Jump(float height)
    {
        isJumping = true; 
        jumpHeight = height;
    }


    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.30F);


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
       
    }
}
