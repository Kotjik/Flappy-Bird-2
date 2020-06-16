using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float scrollSpeed = -1.5f;
    public AudioSource music;

    // Start is called before the first frame update
    void Awake()
    {
        music = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("musicBool") && PlayerPrefs.GetInt("musicBool") == 0)
        {
            print("stop music");
            music.Stop();
        }
        else
        {
            print("play music");
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

        if(gameOver == true)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
        mainMenu.setHighscore(score);

        //speed up the game
        if (score % 2 == 0)
        {
            ChangeSpeed(-0.2f);
        }

        //distance between obstacles smaller
        if (score % 3 == 0)
        {
            obstacleSpawnDistance -= 0.5f;
        }
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        ResetSpeed();
        obstacleSpawnDistance = 10;
    }

    private void ChangeSpeed(float value)
    {
        scrollSpeed += value;
    }

    private void ResetSpeed()
    {
        scrollSpeed = -1.5f;
    }

}
