using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;
    // Start is called before the first frame update
    void Start()
    {
        interactUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(false);
        }
    }
}
