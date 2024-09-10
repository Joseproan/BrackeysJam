using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float pushForce;

    [HideInInspector] public GameObject owner;
    public BasicEnemy enemy;
    internal float power;


    public void SetPushForce(float s)
    {
        pushForce = s;
    }

    private void Start()
    {
        owner = enemy.gameObject;
        SetPushForce(pushForce);
    }
}
