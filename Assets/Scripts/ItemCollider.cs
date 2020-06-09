using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{

    public Bird flappy;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Item Collision
        if (coll.name.StartsWith("ItemFlappyEnlarge"))
        {
            // Get longer in next Move call
            //itemColl = true;

            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds ItemFlappyEnlarge");

        }
        else if (coll.name.StartsWith("ItemFlappyShrink"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds ItemFlappyShrink");

        }
        else if (coll.name.StartsWith("ItemFlappyNormalise"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds ItemFlappyNormalise");

        }
        else if (coll.name.StartsWith("ItemPrefab4"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds Item4");        
        }
    }
}
