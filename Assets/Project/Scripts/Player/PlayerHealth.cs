using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    private float health;
    private Rigidbody rb;
    
    private GameObject lastAttacker;
    private bool pushBack;
    private Vector3 attackPosition;
    private float pushForce;

    float timer;
    float inmuneTime = 0.1f;
    private bool isInmune;
    [SerializeField] private EnemyHealthBar healthBar;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
    }
    private void Update()
    {
        if(timer <= 0)
        {
            isInmune = false;
        }else timer -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (pushBack)
        {
            Vector3 direction = (this.transform.position - attackPosition).normalized;
            direction.y = 0;
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
            pushBack = false;
        }
    }

    public void ReceiveDamage(float damage)
    {
        if(!isInmune)
        {
            health -= damage;
            healthBar.UpdateHealthBar(maxHealth, health);
            isInmune = true;
            timer = inmuneTime;
        }

        if (health <= 0) Die();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHit"))
        {
            EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
            ReceiveDamage(enemyDamage.damage);
            lastAttacker = enemyDamage.owner;
            attackPosition = enemyDamage.owner.transform.position;
            pushForce = enemyDamage.pushForce;
            pushBack = true;
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Defeat");
    }
}
