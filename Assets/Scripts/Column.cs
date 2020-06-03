using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bird>() != null)
        {
            GameController.instance.BirdScored();



            //TODOmakes game faster every 2 points
            if(GameController.instance.score > 0 && GameController.instance.score % 2 == 0)
            {
                float currentSpeed = GameController.instance.scrollSpeed;
                GameController.instance.ChangeGameSpeed(currentSpeed - 1);
            }
           
        }
    }
}
