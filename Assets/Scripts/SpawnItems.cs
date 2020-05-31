using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    // Item Prefab
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public GameObject itemPrefab3;

    public float spawnTime = 4.0f;

    private Vector2 screenBounds;

    // Rect for Borders
   //public RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        //add possible Items to List
        prefabList.Add(itemPrefab1);
        prefabList.Add(itemPrefab2);
        prefabList.Add(itemPrefab3);

        // Spawn items every 4 seconds, starting in 2
        InvokeRepeating("Spawn", 2, spawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Spawn one item
    void Spawn()
    {
        int y = (int)UnityEngine.Random.Range(-screenBounds.y, screenBounds.y);
        int x = (int)screenBounds.x * 2;
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
    
        // Instantiate the food at (x, y)
        Instantiate(prefabList[prefabIndex],
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation */

    }
}
