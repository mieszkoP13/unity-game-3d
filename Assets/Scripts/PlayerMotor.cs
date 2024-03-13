using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float baseSpeed = 5f;
    public float sprintingSpeed = 8f;
    private float speed;
    private float baseHeight;
    private float crouchHeight;
    public float crouchSpeed = 2f;
    private bool isGrounded;
    public readonly float gravity = -9.85f;
    public float jumpHeight = 1.2f;
    private bool crouching = false;
    private bool sprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = baseSpeed;
        baseHeight = controller.height;
        crouchHeight = 0.6f * baseHeight;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void Crouch()
    {
        crouching = !crouching;
        if(crouching)
        {
            speed = crouchSpeed;
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = baseHeight;
            speed = baseSpeed;
        }
    }

    public void SprintPressed()
    {
        sprinting = true;
        speed = sprintingSpeed;
    }

    public void SprintReleased()
    {
        sprinting = false;
        speed = baseSpeed;
    }

    // Receive the inputs from InputManager.cs and apply them to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}