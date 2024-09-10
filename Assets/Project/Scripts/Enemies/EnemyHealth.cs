using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 14f;
    public float health;
    public GameObject explosionSFX;

    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void GetHit(float damage)
    {
        health -= damage;
    }
    private void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            if (!isDead)
            {
                Instantiate(explosionSFX, this.transform.position, Quaternion.identity);
                isDead = true;
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
