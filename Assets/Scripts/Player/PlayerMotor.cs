using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
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
    private Animator animator;
    private PlatformMovement currentPlatform;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = GameManager.Instance.characterController.isGrounded;
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0f);
        speed = baseSpeed;
        baseHeight = GameManager.Instance.characterController.height;
        crouchHeight = 0.6f * baseHeight;
    }

    public void Crouch()
    {
        crouching = !crouching;
        if(crouching)
        {
            speed = crouchSpeed;
            GameManager.Instance.characterController.height = crouchHeight;
        }
        else
        {
            GameManager.Instance.characterController.height = baseHeight;
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

    // Receive the inputs from InputManager.cs and apply them to character characterController
    public void ProcessMove(Vector2 input)
    {
        if(input == Vector2.zero)
            animator.SetFloat("Speed", 0f);
        else if(sprinting)
            animator.SetFloat("Speed", 1f);
        else
            animator.SetFloat("Speed", 0.5f);

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        Vector3 move = transform.TransformDirection(moveDirection) * speed;

        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        move.y = playerVelocity.y;

        if(currentPlatform != null)
            move += currentPlatform.velocity;

        GameManager.Instance.characterController.Move(move * Time.deltaTime);

        isGrounded = GameManager.Instance.characterController.isGrounded;
    }

    public void SetCurrentPlatform(PlatformMovement platform)
    {
        currentPlatform = platform;
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}