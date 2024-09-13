using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCanvas : MonoBehaviour
{
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

    }
    public void ExitGame()
    {
        ExitGame();
    }
}
