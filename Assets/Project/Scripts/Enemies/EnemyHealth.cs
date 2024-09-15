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
    [SerializeField] private AudioSource deathSound;

    [SerializeField] private EnemyHealthBar healthBar;

    [SerializeField]
    private GameObject coin;
    private GameObject[] cloneCoins;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        health = maxHealth + (gameManager.round * 2);
        healthBar.UpdateHealthBar(maxHealth, health);

        cloneCoins = new GameObject[reward];
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
                Instantiate(explosionSFX, this.transform.position, Quaternion.identity);
                isDead = true;
                deathSound.pitch = Random.Range(0.8f, 1.2f);
                deathSound.Play();
                for (int i = 0; i < reward; i++)
                {
                    cloneCoins[i] = Instantiate(coin, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.Euler(90f, 0, 0)) as GameObject;

                    cloneCoins[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0.01f, 0.03f), 1.5f, Random.Range(0.2f, 0.5f)));
                }
                gameManager.enemiesToDefeat++;

                Destroy(gameObject, 0.1f);
            }
        }
    }
}
