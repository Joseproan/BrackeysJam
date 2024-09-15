using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject firstButton;
    private float timer;
    private float timeCooldown;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        timer = 0;
        timeCooldown = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = gameManager.money.ToString();
        ammoText.text = gameManager.ammo.ToString() + " / "+ gameManager.maxAmmo;

        if (gameManager.pause && timer <= 0)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
        if (!gameManager.pause && timer <= 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        ExitGame();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
