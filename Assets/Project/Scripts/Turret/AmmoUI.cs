using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField] private BasicTurret turret;
    [SerializeField] private TextMeshProUGUI text;
    private float ammo, maxAmmo;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas.worldCamera = Camera.main;
        ammo = turret.ammo;
        maxAmmo = turret.maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammo = turret.ammo;
        text.text = ammo + " / " + maxAmmo;
    }
}
