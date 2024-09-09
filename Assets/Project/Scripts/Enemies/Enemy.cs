using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    internal EnemyHealth health;
    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        OnAwake();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ola");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
}
