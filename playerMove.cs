using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;    
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //checks players velocity and if on the ground to stop y velocity increasing
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Retrieves X and Y for vector
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Move vector for player movement using the player controller adjusting with speed
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //basic Jump, checking if grounded first
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Basic gravity when falling increasing acceleration
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
