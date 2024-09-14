using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private Animator animator;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] private float timeBetweenAttacks;
    private bool alreadyAttacked;

    [SerializeField] private float sightRange,attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject projectile;
    [SerializeField] private float projectileVelocityForward = 32f;
    [SerializeField] private float projectileVelocityUp = 8f;
    [SerializeField] private Transform firePoint;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("Run",true);
        animator.SetBool("Idle",false);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            animator.SetTrigger("Attack");
            Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            EnemyDamage bulletDamage = rb.GetComponent<EnemyDamage>();
            bulletDamage.enemy = this.gameObject;
            rb.AddForce(transform.forward * projectileVelocityForward, ForceMode.Impulse);
            rb.AddForce(transform.up * projectileVelocityUp, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked= false;
    }
}
