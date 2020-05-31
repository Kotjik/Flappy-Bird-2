using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool immortal = false;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false) {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }

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
                Debug.Log(GameController.instance.life);
            }
            else
            {
                StartCoroutine("makeImmortal");
                GameController.instance.life--;
                Debug.Log(GameController.instance.life);
                Debug.Log(immortal);
            }
        }
    }

    private IEnumerator makeImmortal()
    {
        immortal = true;
        anim.SetTrigger("Ghost");
        Debug.Log(immortal);
        yield return new WaitForSeconds(3f);
        immortal = false;
        anim.SetTrigger("Ghost");
        Debug.Log(immortal);
        yield return null;

    }



}
