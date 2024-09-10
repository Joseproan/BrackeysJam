using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = gameManager.money.ToString();
    }
}
