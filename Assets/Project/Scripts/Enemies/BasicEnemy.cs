using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    enum states
    {
        SEEK, ATTACK, DESTROY
    }

    private NavMeshAgent agent;
    internal EnemyHealth health;
    private Animator animator;
    private Rigidbody rb;

    private GameObject player;
    private Vector3 playerPos;
    private states currentState;
    private bool isExploding;

    [SerializeField] SphereCollider explosionCollider;
    [SerializeField] private float attackFeedbackTimer = 2f;
    float timer;

    [SerializeField] private GameObject explosionSFX;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentState = states.SEEK;

    }


    private void Update()
    {
        // Si el estado actual es SEEK (el enemigo está buscando al jugador)
        if (currentState == states.SEEK)
        {
            playerPos = player.transform.position;
            agent.SetDestination(playerPos);
            timer = attackFeedbackTimer;
        }

        // Si el estado es ATTACK, puedes agregar la lógica de ataque aquí
        if (currentState == states.ATTACK)
        {
            playerPos = player.transform.position;
            agent.SetDestination(playerPos);
            //agent.enabled = false;
            animator.SetTrigger("Jump");


            if (timer <= 0)
            {
                if (!isExploding)
                {
                    Instantiate(explosionSFX, this.transform.position, Quaternion.identity);
                    isExploding = true;
                    Destroy(gameObject, 0.1f);
                }
            }
            else timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == states.SEEK && other.gameObject.CompareTag("Player"))
        {
            currentState = states.ATTACK;
        }
    }
}
