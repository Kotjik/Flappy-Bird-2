using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menuPanel;
    public GameObject startText;
    public bool gamePaused = false;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameStarted == false && gamePaused == false)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                gameStarted = true;
                Time.timeScale = 1f;
                startText.SetActive(false);

            }
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
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
            startText.SetActive(true);
            if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 1)
            {
                GameController.instance.music.Play();
            }
        }
        else
        {
            Time.timeScale = 0f;
            gamePaused = true;
            gameStarted = false;
            menuPanel.SetActive(true);
            if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 1)
            {
                GameController.instance.music.Pause();
            }
        }
    }

    public void RestartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainMenu");
    }

    private void PlayClickSound()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            GameController.instance.click.Play();
        }
    }
}
