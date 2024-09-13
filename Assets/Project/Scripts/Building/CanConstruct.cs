using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanConstruct : MonoBehaviour
{
    public bool canContruct;
    // Start is called before the first frame update
    void Start()
    {
        canContruct = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Turret"))
        {
            canContruct = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Turret"))
        {
            canContruct = true;
        }
    }
}
