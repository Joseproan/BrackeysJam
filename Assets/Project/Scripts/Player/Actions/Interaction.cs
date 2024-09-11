using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Interaction : MonoBehaviour
{
    //Interact param
    private Transform _transform;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject interactableUI;
   

    private bool canInteract;

    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        if (Physics.Raycast(_transform.position + (Vector3.up * 0.3f) + (_transform.forward * 0.2f), _transform.forward,
    out var hit, 3f, interactableLayer)) canInteract = true;
        else canInteract = false;

        if(canInteract) interactableUI.SetActive(true);
        else interactableUI.SetActive(false);
    }
}
