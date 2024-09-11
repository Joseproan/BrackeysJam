using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmoController : MonoBehaviour
{
    private BasicTurret turret;
    public int newAmmo = 10;
    private void Start()
    {
        turret = GetComponentInParent<BasicTurret>();
    }
    // Start is called before the first frame update
    public void GetAmmo()
    {
        if(turret.maxAmmo > turret.ammo + newAmmo)
        {
            turret.ammo = turret.maxAmmo;
        }else turret.ammo += newAmmo;

    }
}
