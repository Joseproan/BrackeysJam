using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInput playerControls;
    AnimationManager animationManager;

    public Vector2 movementInput;
    private float moveAmount;

    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
    }
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerInput();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue <Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)) + Mathf.Abs(verticalInput);
        animationManager.UpdateAnimationValues(0, moveAmount);
    }
}
