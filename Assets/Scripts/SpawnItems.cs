using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    // Item Prefab
    public GameObject itemPrefab;
    public float spawnTime = 4.0f;

    private Vector2 screenBounds;

    // Rect for Borders
   //public RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn items every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, spawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Spawn one item
    void Spawn()
    {
        int y = (int)UnityEngine.Random.Range(-screenBounds.y, screenBounds.y);
        int x = (int)screenBounds.x * 2;

        // Instantiate the food at (x, y)
       Instantiate(itemPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation */

    }
}
