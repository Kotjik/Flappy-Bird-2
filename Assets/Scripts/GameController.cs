using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public int score = 0;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public int life = 2;
    private Menu menuScript;
    private MainMenu mainMenu;
    public float obstacleSpawnDistance = 10f;
    public float scrollSpeed = -1f;
    public int sizeState = 2;
    private AudioSource[] sounds;
    public AudioSource music;
    private AudioSource scored;
    public AudioSource click;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        sounds = GetComponents<AudioSource>();
        music = sounds[0];
        scored = sounds[1];
        click = sounds[2];

        if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 0)
        {
            //print("stop music");
            music.Stop();
        }
        else
        {
            //print("play music");
            music.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        menuScript = GameObject.Find("GameController").GetComponent<Menu>();
        if (menuScript.gamePaused == false)
        {
            if (gameOver == true)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
        if (life > 5)
        {
            life = 5;
        }
        if (life == 5)
        {
            life5.SetActive(true);
        }


        if (life == 4)
        {
            life4.SetActive(true);
            life5.SetActive(false);
        }

        if (life == 3)
        {
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(false);
        }
        if (life == 2)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
        }
        if (life == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }
        if (life == 0)
        {
            life1.SetActive(false);
        }
    }

    public void BirdScored()
    {
        mainMenu = GameObject.Find("ScriptManager").GetComponent<MainMenu>();
                
        if (gameOver == true)
        {
            return;
        }

        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            scored.Play();
        }

        score++;
        scoreText.text = "Score: " + score.ToString();
        mainMenu.SetHighscore(score);

        //speed up the game
        ChangeSpeed(score);
        Debug.Log("ScrollSpeed = " + scrollSpeed);

        //distance between obstacles smaller
        ChangeObstacleSpawnDistance(score);
        Debug.Log("ObstaceSpawnDistance = " + obstacleSpawnDistance);
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        ResetSpeed();
        obstacleSpawnDistance = 10;
        music.Stop();
    }

    private void ChangeSpeed(float score)
    {
        scrollSpeed = (1 + Mathf.Sqrt(score) / (2.8f)) * -1;
    }

    private void ChangeObstacleSpawnDistance(float score)
    {
        if(10 - Mathf.Sqrt(score) / 2 > 2)
        {
            obstacleSpawnDistance = 10 - Mathf.Sqrt(score) / 2;
        }

    }

    private void ResetSpeed()
    {
        scrollSpeed = -1.5f;
    }

}
