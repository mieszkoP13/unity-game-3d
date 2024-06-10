using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public PlayerInput.OtherActions other;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        other = playerInput.Other;

        onFoot.Jump.performed += ctx => GameManager.Instance.Motor.Jump();
        onFoot.Crouch.performed += ctx => GameManager.Instance.Motor.Crouch();
        onFoot.SprintStart.performed += ctx => GameManager.Instance.Motor.SprintPressed();
        onFoot.SprintFinish.performed += ctx => GameManager.Instance.Motor.SprintReleased();
        onFoot.Drop.performed += ctx => GameManager.Instance.Interact.Drop();
        other.Pause.performed += ctx => GameManager.Instance.pauseMenu.TogglePause();
        //other.Pause.performed += ctx => CutsceneTrigger.FinishCut();
    }

    void FixedUpdate()
    {
        // tell the playermotor to move using the value from movement action
        GameManager.Instance.Motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        // tell the playermotor to move using the value from movement action
        GameManager.Instance.Look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
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
