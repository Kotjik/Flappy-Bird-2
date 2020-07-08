using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private bool moveUp;
    private int movedir = 1;
    private int upMovementBorder = -1;
    private int downMovementBorder = -6;
    



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


        //moves the object up and down
        if(gameObject.tag == "Column")
        {
            if ( transform.GetChild(1).transform.position.y -10.24f > upMovementBorder && moveUp == true )
            {
                movedir *= -1;
                moveUp = false;
            }

             if (transform.GetChild(0).transform.position.y < downMovementBorder && moveUp == false) 
             {
                 movedir *= -1;
                 moveUp = true;
             }

            rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, movedir);
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
}
