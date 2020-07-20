using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public int pauseTriggerTime = 7;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bird>() != null)
        {
            GameController.instance.BirdScored();
            GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(pauseTriggerTime);
            GetComponent<Collider2D>().enabled = true;            
        }
        else if (collision.name.StartsWith("Item"))
        {
            Destroy(collision.gameObject);
        }
    }
}
