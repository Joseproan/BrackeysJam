using BehaviorDesigner.Runtime.Tasks.Unity.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool newRound;
    private float timer;
    public float timeBetween;

    private bool relaxTime;

    public int maxNewEnemies, minNewEnemies;
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
        relaxTime = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == gameState.Battle)
        {

            if (numEnemies > 0 && timer <= 0)
            {
                timer = timeBetween;
                enemies[numEnemies - 1] = Instantiate(typeOfEnemies[0], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position,
                    Quaternion.identity);
                numEnemies--;
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if(numEnemies <= 0 && !relaxTime)
            {
                state = gameState.Relax;
                relaxTime = true;
                NewRound();
            }
        }
        if(newRound)
        {
            enemies = new GameObject[numEnemies];
            state = gameState.Battle;
            newRound = false;
            relaxTime=false;
        }
    }
    public void UpdateGameState(gameState newState)
    {
        state = newState;

    }
    public void NewRound()
    {
        numEnemies = fixNumEnemies + Random.Range(minNewEnemies, maxNewEnemies);
        round++;
    }

}
