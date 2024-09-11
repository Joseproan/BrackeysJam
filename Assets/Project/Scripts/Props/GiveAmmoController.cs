using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAmmoController : MonoBehaviour
{
    private int propLevel;
    public int ammo = 10;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        propLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GiveAmmo()
    {
        if (gameManager.ammo + CalculateLevel(propLevel) <= gameManager.maxAmmo)
        {
            gameManager.ammo += CalculateLevel(propLevel);
        }
        else {
            gameManager.ammo = gameManager.maxAmmo;
           }
    }

    private int CalculateLevel(int level)
    {
        level = propLevel;
        ammo = 10 * level;
        return ammo;
    }
}
