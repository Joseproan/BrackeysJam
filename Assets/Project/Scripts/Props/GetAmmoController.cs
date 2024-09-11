using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmoController : MonoBehaviour
{
    GameManager gameManager;
    private BasicTurret turret;
    public int newAmmo = 10;
    private void Start()
    {
        gameManager = GameManager.instance;
        turret = GetComponentInParent<BasicTurret>();
    }
    // Start is called before the first frame update
public void GetAmmo()
{
    int neededAmmo = turret.maxAmmo - turret.ammo;  // Munici�n que le falta a la torreta

    // Calcula la cantidad de munici�n que se le puede dar (el m�nimo entre lo que le falta y lo que tiene el jugador)
    int ammoToGive = Mathf.Min(neededAmmo, gameManager.ammo, newAmmo); 

    turret.ammo += ammoToGive;  // A�ade la cantidad calculada a la torreta
    gameManager.ammo -= ammoToGive;  // Resta la misma cantidad de la munici�n del jugador
}
}
