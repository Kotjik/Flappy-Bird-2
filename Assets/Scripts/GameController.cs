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
    public GameObject life1White;
    public GameObject life2White;
    public GameObject life3White;
    public int life = 2;
    private Menu menuScript;
    private MainMenu mainMenu;
    public float obstacleSpawnDistance = 10f;
    public float scrollSpeed = -1.5f;
    public AudioSource music;

    // Start is called before the first frame update
    void Awake()
    {
        menuScript = GameObject.Find("GameController").GetComponent<Menu>();
        music = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("musicBool") == 0)
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
        if (life == 2)
        {
            life3White.SetActive(true);
        }
        if (life == 1)
        {
            life2White.SetActive(true);
        }
        if (life == 0)
        {
            life1White.SetActive(true);
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
