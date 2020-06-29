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

    public float spawnTime = 7.0f;
    public float columnMin = -2f;

    private Vector2 screenBounds;
    private int x, y;

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
        prefabList.Add(itemAddLife);
        
        // Spawn items every 4 seconds, starting in 2
        InvokeRepeating("Spawn", 2, spawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Spawn one item
    void Spawn()
    {
        spawnVector();
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
        bool usefullItem = true;

        // Instantiate the food at (x, y)
        if (prefabIndex==6 && GameController.instance.life >= 4)
        {
            prefabIndex = 5;
        }
        if(prefabIndex == 0 && GameController.instance.sizeState == 3)
        {
            usefullItem = false;
        }
        if (prefabIndex == 1 && GameController.instance.sizeState == 1)
        {
            usefullItem = false;

        }
        if (prefabIndex == 2 && GameController.instance.sizeState == 2)
        {
            usefullItem = false;

        }

        if (usefullItem)
        {
            Instantiate(prefabList[prefabIndex],
                        new Vector2(x, y),
                        Quaternion.identity); // default rotation */
        }
        else
        {
            Debug.Log("item not usefull");
        }
    }

     private void spawnVector()
    {
        bool vectorOK = false;
        while (!vectorOK)
        {
            y = (int)UnityEngine.Random.Range(columnMin, screenBounds.y);
            x = (int)(screenBounds.x * 1.1);
            // freeze without error after some time
            //vectorOK = Physics2D.OverlapCircle(new Vector2(x, y), 0.5f) == null;
            Debug.Log("new vector " + vectorOK);
            // instead of line 92:
            vectorOK = true;
        }
    }
}
