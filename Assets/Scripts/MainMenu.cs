using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    private int savedHighscore = 0;
    private int savedMusic = 1;
    public Text highscore;
    public Text music;
    public bool playMusic = true;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit game");
    }

    public void OpenSettings()
    {
        // get savedHighscore and show. If there is no saved highscore, savedHighscore = 0;
        if (PlayerPrefs.HasKey("highscore"))
        {
            savedHighscore = PlayerPrefs.GetInt("highscore");
        }
        highscore.text = savedHighscore.ToString();

        // get musicSettings and show. If there is no saved musicBool, saved Music = 1 (music on);
        if (PlayerPrefs.HasKey("musicBool"))
        {
            savedMusic = PlayerPrefs.GetInt("musicBool");
        }
        
        if(savedMusic == 1)
        {
            music.text = "on";
        }
        else
        {
            music.text = "off";
        }
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void setHighscore(int score)
    {
        //checks if there is still a savedHighscore, else it is 0
        if (PlayerPrefs.HasKey("highscore"))
        {
            savedHighscore = PlayerPrefs.GetInt("highscore");
        }

        if (score > savedHighscore)
        {
            savedHighscore = score;
            PlayerPrefs.SetInt("highscore", savedHighscore);
            print("score saved: " + savedHighscore);
        }
    }

    public void changeMusicSettings()
    {
        if (music.text.Equals("off"))
        {
            music.text = "on";
            playMusic = true;
        } else
        {
            music.text = "off";
            playMusic = false;
        }
        PlayerPrefs.SetInt("musicBool", playMusic ? 1 : 0);
    }

}
