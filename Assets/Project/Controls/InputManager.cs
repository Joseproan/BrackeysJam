using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInput playerControls;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
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
    }
}
