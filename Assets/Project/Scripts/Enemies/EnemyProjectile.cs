using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] GameObject sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(sfx, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Instantiate(sfx, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
