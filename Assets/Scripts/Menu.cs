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
            if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 1)
            {
                GameController.instance.music.Play();
            }
        }
        else
        {
            Time.timeScale = 0f;
            gamePaused = true;
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
