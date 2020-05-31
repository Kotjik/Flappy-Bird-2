using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    bool itemColl = false;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Item Collision?
        if (coll.name.StartsWith("ItemPrefab"))
        {
            // Get longer in next Move call
            //itemColl = true;

            // Remove the Food
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds");
        }
        // Collided with Tail or Border
        else
        {
        }
    }
}
