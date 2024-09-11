using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicTurret : MonoBehaviour
{
    enum states
    {
        PATROL, ATTACK
    }

    private states currentState;
    private Transform target;
    private float fireCountdown = 0f;

    [Header("Turret Components")]
    [SerializeField] private Transform cannon;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Turret Stats")]
    public float range = 15f;
    public float fireRate = 1F;
    public float turnSpeed = 10f;
    public float damage = 3f;
    public int maxAmmo = 20;

    [Header("Detail Stats")]
    public float rotationPatrol = 20f;

    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        currentState = states.PATROL;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        ammo = maxAmmo;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            currentState = states.ATTACK;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) currentState = states.PATROL;
        if (currentState == states.PATROL)
        {
            cannon.transform.Rotate(0, rotationPatrol * Time.deltaTime, 0);
        }
        if(currentState == states.ATTACK)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(cannon.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
            cannon.rotation = Quaternion.Euler(0f, rotation.y, 0);

            if(fireCountdown <= 0)
            {
                if(ammo > 0) Shoot();
                fireCountdown = 1F / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
       Bullet bullet = bulletGO.GetComponent<Bullet>();
       bullet.damage = damage;
       if(bullet != null)
        {
            bullet.Seek(target);
        }

        ammo--;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
