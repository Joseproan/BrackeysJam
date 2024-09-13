using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject menuItems;
    [SerializeField] private GameObject crediPanel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject backButtonCredits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("Gym");
    }

    public void Credits()
    {
        crediPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backButtonCredits);
    }

    public void BackButtonCredits()
    {
        crediPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void ExitGame()
    {
        ExitGame();
    }
}
