using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    // Item Prefab
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject itemBirdIncrease;
    public GameObject itemBirdDecrease;
    public GameObject itemBirdNormalise;
    public GameObject itemSpeedUp;
    public GameObject itemSpeedDown;
    public GameObject itemInvulnerable;
    public GameObject itemAddLife;

    public float spawnTime = 4.0f;
    public float columnMin = -2f;

    private Vector2 screenBounds;

    // Rect for Borders
   //public RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        //add possible Items to List
        prefabList.Add(itemBirdIncrease);
        prefabList.Add(itemBirdDecrease);
        prefabList.Add(itemBirdNormalise);
        prefabList.Add(itemSpeedUp);
        prefabList.Add(itemSpeedDown);
        prefabList.Add(itemInvulnerable);
        if (GameController.instance.life <= 4)
        {
            prefabList.Add(itemAddLife);
        }
        // Spawn items every 4 seconds, starting in 2
        InvokeRepeating("Spawn", 2, spawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Spawn one item
    void Spawn()
    {
        int y = (int)UnityEngine.Random.Range(columnMin, screenBounds.y);
        int x = (int)screenBounds.x * 2;
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
    
        // Instantiate the food at (x, y)
        Instantiate(prefabList[prefabIndex],
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation */

    }
}
