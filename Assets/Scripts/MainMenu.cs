using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public int savedHighscore = 0;
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
        // get savedHighscore and show
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        // get musicSettings and show
        savedMusic = PlayerPrefs.GetInt("musicBool");
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
