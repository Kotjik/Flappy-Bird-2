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
    public float scrollSpeed = -1.5f;
    public int score = 0;
    

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        Debug.Log("speed" + scrollSpeed);


        
    }

    public void BirdScored()
    {
        if(gameOver == true)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
       
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        //TODO
        DefaultGameSpeed();
    }



    //TODO to make game / bird / obstacles faster or slower
    public void ChangeGameSpeed(float speed)
    {
        scrollSpeed = speed;
        Debug.Log(scrollSpeed);
    }
    //TODO
    public void DefaultGameSpeed()
    {
        scrollSpeed = -1.5f;
    }
}
