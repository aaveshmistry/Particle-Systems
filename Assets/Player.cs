using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float speed = 8.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float stamina;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        stamina = 100;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
            { moveDirection.y = jumpSpeed; }
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            {
                if (stamina > 0)
                {
                    stamina -= 20 * Time.deltaTime; speed = 8f;
                }
            }
            else
            {
                if (stamina < 100)
                {
                    stamina += 5 * Time.deltaTime;
                }
                speed = 4f;
            }
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}