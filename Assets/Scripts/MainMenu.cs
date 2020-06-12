using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public int savedHighscore = 0;
    public Text highscore;

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

}
