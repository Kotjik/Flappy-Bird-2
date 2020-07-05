using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menuPanel;
    public bool gamePaused = false;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        music = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 0)
        {
            print("stop music");
            music.Stop();
        }
        else
        {
           // print("play music");
            music.Play();
        }
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
                music.Play();
            }
        }
        else
        {
            Time.timeScale = 0f;
            gamePaused = true;
            menuPanel.SetActive(true);
            music.Pause();
            if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 1)
            {
                music.Pause();
            }
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
