using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    //necessary?
    bool itemColl = false;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Item Collision
        if (coll.name.StartsWith("ItemPrefab1"))
        {
            // Get longer in next Move call
            //itemColl = true;

            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds Item1");
        }
        else if (coll.name.StartsWith("ItemPrefab2"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds Item2");
        }
        else if (coll.name.StartsWith("ItemPrefab3"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds Item3");
        }
    }
}
