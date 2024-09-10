using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private PlayerInput _playerInput;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.Player.Interact.performed += DoInteract;
    }

    private void OnDisable()
    {
        _playerInput.Player.Interact.performed += DoInteract;
    }

    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Interact");
    }
}
