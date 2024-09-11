using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set;}

    public enum GameState
    {
        Relax, Battle
    }
    public GameState state;

    //General Stats
    public int money;
    public int ammo;
    public int maxAmmo;
    public int round;
    public int numEnemies;
    public int incEnemyPerRound;

    private bool newGame;

    PlayerInput playerControls;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Debug.Log("There is a Game Manager already!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if(newGame)
        {
            state = GameState.Relax;
            round = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Relax)
        {

        }
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

    }


}
