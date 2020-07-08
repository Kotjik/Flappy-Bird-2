using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 200f;
    public float sideForce = 5f;
    public float downForce= 7f;
    public float rotationSpeed = 1.3f;
    public int rotationDegree = -60;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private GameObject flappy;
    private bool immortal = false;
    private Menu menuScript;
    private bool pickedUpTimedItem = false;
    private float itemTimer = 0.0f;
    private SoundHandler soundHandler;

    // Start is called before the first frame update
    void Start()
    {
        menuScript = GameObject.Find("GameController").GetComponent<Menu>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundHandler = GetComponent<SoundHandler>();
        flappy = this.gameObject;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuScript.gamePaused == false)
        {
            if (isDead == false)
            {
                //Controls
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(Vector2.up * upForce);
                    anim.SetTrigger("Flap");
                }
                else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    //transform.Translate(new Vector2(sideForce * Time.deltaTime, 0), Space.World);
                    transform.Translate(Vector2.right * sideForce * Time.deltaTime);

                    if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                    {
                        rb2d.AddForce(Vector2.down * downForce);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * sideForce * Time.deltaTime);

                    if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                    {
                        rb2d.AddForce(Vector2.down * downForce);
                    }
                }
                else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    rb2d.AddForce(Vector2.down * downForce);
                }
                // for testing
                else if (Input.GetKey(KeyCode.T))
                {
                    //StartCoroutine("makeImmortal");
                    GameController.instance.score = 30;

                }

            }
        }

        //if(GameController.instance.score % 2 == 1)
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            FlappyShrinkScale();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            FlappyEnlargeScale();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            FlappyNormaliseScale();
        }

        //Keep Flappy within Camera bounds
        KeepWithinCameraBounds();

        //If picked up timed Items (SpeedUp or SpeedDown), set timer
        SetItemTimer(3f);
        
        //if flappy is falling, rotate flappy 
        RotateOnFall(rotationDegree, rotationSpeed);
               
    }

    private void SetItemTimer(float time)
    {
        if (pickedUpTimedItem == true)
        {
            itemTimer += Time.deltaTime;
            if (itemTimer > time)
            {
                ResetForceValues();
                pickedUpTimedItem = false;
                itemTimer = 0f;
            }

        }
    }

    private void KeepWithinCameraBounds()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void RotateOnFall(int degree, float speed) {
        if (rb2d.velocity.y < -0.1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, degree), Time.deltaTime * speed);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    private void ResetForceValues()
    {
        upForce = 200f;
        sideForce = 5f;
        downForce = 7f;
    }


    public void FlappyEnlargeScale()
    {
        flappy.transform.localScale = new Vector2(1.2f, 1.2f);
        GameController.instance.sizeState = 3;
    }

    public void FlappyShrinkScale()
    {
        flappy.transform.localScale = new Vector2(0.8f, 0.8f);
        GameController.instance.sizeState = 1;
    }

    public void FlappyNormaliseScale()
    {
        flappy.transform.localScale = new Vector2(1f, 1f);
        GameController.instance.sizeState = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On Die --> Bird standsStill
        //rb2d.velocity = Vector2.zero;
        if (immortal == false)
        {
           
            if (GameController.instance.life == 0)
            {
                
                isDead = true;
                anim.SetTrigger("Die");
                GameController.instance.BirdDied();
//                Debug.Log(GameController.instance.life);
    
            }
            else
            {
                StartCoroutine("makeImmortal");
                GameController.instance.life--;
                soundHandler.PlayCollision();
//                Debug.Log(GameController.instance.life);
               // Debug.Log(immortal);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Item Collision
        if (collision.name.StartsWith("ItemFlappyEnlarge"))
        {
            FlappyEnlargeScale();
            Destroy(collision.gameObject);
            soundHandler.PlayScale();
        }
        else if (collision.name.StartsWith("ItemFlappyShrink"))
        {
            FlappyShrinkScale();
            Destroy(collision.gameObject);
            soundHandler.PlayScale();
        }
        else if (collision.name.StartsWith("ItemFlappyNormalise"))
        {
            FlappyNormaliseScale();
            Destroy(collision.gameObject);
            soundHandler.PlayScale();
        }
        else if (collision.name.StartsWith("ItemInvulnerable"))
        {
            StartCoroutine("makeImmortal");
            Destroy(collision.gameObject);
            soundHandler.PlayInvulnerable();
        }
        else if (collision.name.StartsWith("ItemAddLife"))
        {
            if (GameController.instance.life <= 4)
            {
                GameController.instance.life++;
                Destroy(collision.gameObject);
                soundHandler.PlayLife();
//                Debug.Log(GameController.instance.life);
            }
            else
            {
                Debug.Log("max lifepoints reached");
            }
        }else if (collision.name.StartsWith("ItemSpeedUp"))
        {
            upForce = 250f;
            sideForce = 7f;

            pickedUpTimedItem = true;
            Destroy(collision.gameObject);
            soundHandler.PlaySpeedUp();

        }
        else if (collision.name.StartsWith("ItemSpeedDown"))
        {
            upForce = 150f;
            sideForce = 3f;
            downForce = 9f;
            
            pickedUpTimedItem = true;
            Destroy(collision.gameObject);
            soundHandler.PlaySpeedDown();
        }
    }


    private IEnumerator makeImmortal()
    {
        if (immortal == false)
        {
            immortal = true;
            anim.SetTrigger("Ghost");
//            Debug.Log(immortal);
            yield return new WaitForSeconds(3f);
            immortal = false;
            anim.SetTrigger("Ghost");
       //     Debug.Log(immortal);
            yield return null;
        }
    }



}
