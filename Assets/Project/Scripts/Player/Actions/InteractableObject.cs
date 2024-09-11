using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Interactions
{
    public class InteractableObject : MonoBehaviour, Iinteraction
    {
        private bool isOn;
        [SerializeField] private UnityEvent _stopInteract;
        [SerializeField] private UnityEvent _onInteract;

        UnityEvent Iinteraction._onInteract
        {
            get => _onInteract;
            set => _onInteract = value;
        }

        public void Interact()
        {
            if (isOn)
            {
                _stopInteract.Invoke();
            }
            else
            {
                _onInteract.Invoke();
            }
            isOn = !isOn;
        }
    }
}

