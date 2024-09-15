using BehaviorDesigner.Runtime.Tasks.Unity.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set;}

    public enum gameState
    {
        Relax, Battle
    }
    public gameState state;

    //General Stats
    public int money;
    public int ammo;
    public int maxAmmo;
    public int round;
    internal int numEnemies;
    public int fixNumEnemies;
    public int incEnemyPerRound;

    private bool newGame;

    PlayerInput playerControls;
    public GameObject[] typeOfEnemies;
    private GameObject[] enemies;
    public Transform[] spawnPoints;
    [SerializeField] private GameObject pressText;

    public bool newRound;
    private float timer;
    public float timeBetween;

    private bool relaxTime;

    public int maxNewEnemies, minNewEnemies;
    public AudioSource newRoundSound;

    public int enemiesToDefeat;
    public int fixEnemiesToDefeat;

    public bool pause;
    public int winCondition = 3;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Debug.Log("There is a Game Manager already!");


    }
    // Start is called before the first frame update
    void Start()
    {
     
            state = gameState.Relax;
            round = 1;
            numEnemies = fixNumEnemies;
        enemiesToDefeat = 0;
        relaxTime = true;
        pause = false;
        pressText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == gameState.Relax)
        {
            pressText.SetActive(true);
        }
        if(state == gameState.Battle)
        {
            pressText.SetActive(false);
            if (numEnemies > 0 && timer <= 0)
            {
                timer = timeBetween;
                if(round == 1)
                enemies[numEnemies - 1] = Instantiate(typeOfEnemies[0], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position,
                    Quaternion.identity);
                else enemies[numEnemies - 1] = Instantiate(typeOfEnemies[Random.Range(0, typeOfEnemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position,
                    Quaternion.identity);
                numEnemies--;
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if(enemiesToDefeat == fixNumEnemies && !relaxTime)
            {
                state = gameState.Relax;
                relaxTime = true;
                NewRound();
            }
        }
        if(newRound)
        {
            pressText.SetActive(true);
            enemies = new GameObject[numEnemies];
            state = gameState.Battle;
            newRound = false;
            relaxTime=false;
        }
        if(round == winCondition)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    public void UpdateGameState(gameState newState)
    {
        state = newState;

    }
    public void NewRound()
    {
        newRoundSound.Play();
        fixNumEnemies += Random.Range(minNewEnemies, maxNewEnemies);
        enemiesToDefeat = 0;
        numEnemies = fixNumEnemies;
        round++;
    }

}
