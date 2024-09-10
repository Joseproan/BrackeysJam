using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Interactions
{
    public interface Iinteraction
    {
        public UnityEvent _onInteract { get; protected set; }
        public void Interact();
    }
}

