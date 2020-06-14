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
        else if (coll.name.StartsWith("ItemAddLife"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds add life");        
        }
        else if (coll.name.StartsWith("ItemInvulnerable"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds invulnerable");
        }
        else if (coll.name.StartsWith("ItemSpeedUp"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds speed up");
        }
        else if (coll.name.StartsWith("ItemSpeedDown"))
        {
            // Remove the Item
            Destroy(coll.gameObject);

            //GameController.instance.BirdScored();
            UnityEngine.Debug.Log("Bounds speed down");
        }
    }
}
