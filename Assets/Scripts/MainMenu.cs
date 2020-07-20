using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject controlsPanel;
    public GameObject mainPanel;
    private int savedHighscore = 0;
    private int savedMusic = 1;
    private int savedSound = 1;
    public Text highscore;
    public Text music;
    public Text sound;
    public Text controls;
    public bool playMusic = true;
    public bool playSound = true;
    private bool controlsActive = false;
    private AudioSource[] sounds;
    private AudioSource backgroundMusic;
    private AudioSource click;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        sounds = GetComponents<AudioSource>();
        backgroundMusic = sounds[0];
        click = sounds[1];

        if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 0)
        {
            backgroundMusic.Stop();
        }
        else
        {
            backgroundMusic.Play();
        }
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene("Main");
        backgroundMusic.Stop();
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
        print("quit game");
    }

    public void OpenSettings()
    {
        PlayClickSound();
        // get savedHighscore and show. If there is no saved highscore, savedHighscore = 0;
        if (PlayerPrefs.HasKey("highscore"))
        {
            savedHighscore = PlayerPrefs.GetInt("highscore");
        }
        highscore.text = savedHighscore.ToString();

        // get musicSettings and show. If there is no saved musicBool, saved music = 1 (music on);
        if (PlayerPrefs.HasKey("musicBool"))
        {
            savedMusic = PlayerPrefs.GetInt("musicBool");
        }

        if (savedMusic == 1)
        {
            music.text = "on";
        }
        else
        {
            music.text = "off";
        }
        
        // get soundSettings and show. If there is no saved soundBool, saved sound = 1 (sound on);
        if (PlayerPrefs.HasKey("soundBool"))
        {
            savedSound = PlayerPrefs.GetInt("soundBool");
        }

        if (savedSound == 1)
        {
            sound.text = "on";
        }
        else
        {
            sound.text = "off";
        }
        settingsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        PlayClickSound();
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void SetHighscore(int score)
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

    public void ChangeMusicSettings()
    {
        if (music.text.Equals("off"))
        {
            music.text = "on";
            backgroundMusic.Play();
            playMusic = true;
        }
        else
        {
            music.text = "off";
            backgroundMusic.Stop();
            playMusic = false;
        }
        PlayerPrefs.SetInt("musicBool", playMusic ? 1 : 0);
        PlayClickSound();
    }

    public void ChangeSoundSettings()
    {
        if (sound.text.Equals("off"))
        {
            sound.text = "on";
            playSound = true;
        }
        else
        {
            sound.text = "off";
            playSound = false;
        }
        
        PlayerPrefs.SetInt("soundBool", playSound ? 1 : 0);
        PlayClickSound();
    }

    public void ResetHighscore()
    {
        PlayClickSound();
        savedHighscore = 0;
        PlayerPrefs.SetInt("highscore", savedHighscore);
        highscore.text = savedHighscore.ToString();
    }

    public void ShowControls()
    {
        if (controlsActive)
        {
            controlsPanel.SetActive(false);
            mainPanel.SetActive(true);
            controlsActive = false;
            controls.text = "controls";
        }
        else
        {
            controlsPanel.SetActive(true);
            mainPanel.SetActive(false);
            controlsActive = true;
            controls.text = "back";
        }
        PlayClickSound();
    }

    private void PlayClickSound()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            click.Play();
        }
    }

}
