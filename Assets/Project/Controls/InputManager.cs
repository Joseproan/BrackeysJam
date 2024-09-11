using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Interactions;
public class InputManager : MonoBehaviour
{
    PlayerInput playerControls;
    AnimationManager animationManager;

    public Vector2 movementInput;
    private float moveAmount;

    public float verticalInput;
    public float horizontalInput;

    //Interact param
    private Transform _transform;
    [SerializeField] private LayerMask interactableLayer;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
        _transform = transform;
    }
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerInput();

            playerControls.Player.Movement.performed += i => movementInput = i.ReadValue <Vector2>();

        }
        
        playerControls.Enable();
        playerControls.Player.Interact.performed += DoInteract;
    }
    private void OnDisable()
    {
        
        playerControls.Disable();
        playerControls.Player.Interact.performed += DoInteract;
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

    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        if (!Physics.Raycast(_transform.position + (Vector3.up * 0.3f) + (_transform.forward * 0.2f), _transform.forward,
            out var hit, 3f, interactableLayer)) return;


        if(!hit.transform.TryGetComponent(out InteractableObject interactable)) return;
        interactable.Interact();
    }
}
