using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private bool moveUp;
    private float movedir = 1f;
    private float upMovementBorderSharp = -2f;
    private float downMovementBorderSharp = -7f;
    private float upMovementBorderDull = -13.2f;
    private float downMovementBorderDull = 4.2f;
    private bool moveObstacles = false;

    // Start is called before the first frame update
    void Start()
    {
        moveUp = true;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);


        //Change ObstacleMovement according to random generated Integer
        if (GameController.instance.score > 0)
        {
            moveObstacles = true;
        }
        

        //moves the object up and down
        if (moveObstacles == true)
        {
            //fette Pfahle
            if (gameObject.name.StartsWith("Pile("))
            {
                if (transform.GetChild(1).transform.position.y - 10.24f > upMovementBorderDull && moveUp == true)
                {
                    movedir *= -1;
                    moveUp = false;
                }

                if (transform.GetChild(0).transform.position.y < downMovementBorderDull && moveUp == false)
                {
                    movedir *= -1;
                    moveUp = true;
                }

                ChangeMovementSpeed(100);
                rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, movedir);
            }

            //stumpfe Pfahle
            if (gameObject.name.StartsWith("Pile1("))
            {
                if (transform.GetChild(1).transform.position.y - 10.24f > upMovementBorderSharp && moveUp == true)
                {
                    movedir *= -1;
                    moveUp = false;
                }

                if (transform.GetChild(0).transform.position.y < downMovementBorderSharp && moveUp == false)
                {
                    movedir *= -1;
                    moveUp = true;
                }
                ChangeMovementSpeed(100);
                rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, movedir);
            }
            
        }

        //delete unused prefabs
        if (transform.position.x < -screenBounds.x)
        {
            if (transform.name.StartsWith("Item"))
            {
                Destroy(this.gameObject);
            }
        }

        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private float GapSize()
    {
        float gapsize;

        float lowerColumY = transform.GetChild(0).transform.position.y;

        float upperColY = transform.GetChild(1).transform.position.y - 10.24f;

        gapsize = Mathf.Abs(lowerColumY - upperColY);

        return gapsize;
    }

    private void ChangeMovementSpeed(float score)
    {
        if(movedir < 0)
        {
            movedir = -1 * (float)((Mathf.Sqrt(score) / 2) * 0.3);
        }
        else if(movedir > 0)
        {
            movedir = (float)((Mathf.Sqrt(score) / 2) * 0.3);
        }
        
    }
}
