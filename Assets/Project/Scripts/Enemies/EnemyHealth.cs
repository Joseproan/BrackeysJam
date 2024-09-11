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
    float ola;
    int ola2;

    [SerializeField] private EnemyHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        health = maxHealth + gameManager.round;
        healthBar.UpdateHealthBar(maxHealth, health);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void GetHit(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth, health);
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
