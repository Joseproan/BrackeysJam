using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    private float health;
    private Rigidbody rb;
    
    private GameObject lastAttacker;
    private bool pushBack;
    private Vector3 attackPosition;
    private float pushForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        health = maxHealth;
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
        health -= damage;

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
    }
}
