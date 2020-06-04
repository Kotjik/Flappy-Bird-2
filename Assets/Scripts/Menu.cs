using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menuPanel;
    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseOrResume();
        }
    }

    public void PauseOrResume()
    {
        if (gamePaused)
        {
            //hier gegebenenfalls Geschwindigkeit anpassen
            Time.timeScale = 1f;
            gamePaused = false;
            menuPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            gamePaused = true;
            menuPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
