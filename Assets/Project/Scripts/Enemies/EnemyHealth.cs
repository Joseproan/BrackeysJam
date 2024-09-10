using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private GameManager gameManager;
    public float maxHealth = 14f;
    public float health;
    public GameObject explosionSFX;

    public int reward = 3;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        gameManager = GameManager.instance;
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
            if (!isDead)
            {
                gameManager.money += reward;
                Instantiate(explosionSFX, this.transform.position, Quaternion.identity);
                isDead = true;
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
