using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public PlayerInput.OtherActions other;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInteract interact;
    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        other = playerInput.Other;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        interact = GetComponent<PlayerInteract>();

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.SprintStart.performed += ctx => motor.SprintPressed();
        onFoot.SprintFinish.performed += ctx => motor.SprintReleased();
        onFoot.Drop.performed += ctx => interact.Drop();
        other.Pause.performed += ctx => pauseMenu.TogglePause();
    }

    void FixedUpdate()
    {
        // tell the playermotor to move using the value from movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        // tell the playermotor to move using the value from movement action
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
        other.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
        other.Disable();
    }
}
