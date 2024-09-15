using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 0f;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;

    [SerializeField] private AudioSource coinSound;
    private GameObject player;

    [SerializeField] private float speedToPlayer = 5f;
    [SerializeField] private float distanceToPlayer = 5f;

    private void Start()
    {
        gameManager = GameManager.instance;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        //Forward Direction
        if (ForwardX == true)
        {
            transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < distanceToPlayer)  // Distancia mínima para detenerse
        {
            float speed = speedToPlayer; // Define la velocidad a la que se moverá el objeto
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.money += 1;
            coinSound.Play();
            Destroy(gameObject,0.1f);
        }
    }
}
