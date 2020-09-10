using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
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

    public float columnMin = -2f;

    // In welchem Sekundenabstand ( Random zwischen beiden Zahlen) die Items spawnen
    float[] BirdIncreaseFrequency = { 8f, 18f };
    float[] BirdDecreaseFrequency = { 8f, 16f };
    float[] BirdNormaliseFrequency = { 7f, 14f };
    float[] SpeedUpFrequency = { 10f, 25f };
    float[] SpeedDownFrequency = { 7f, 13f };
    float[] InvulnerableFrequency = { 5f, 10f };
    float[] AddLifeFrequency = { 10f, 25f };

    private Vector2 screenBounds;
    private int x, y;
    private bool justSpawned = false;



    // Rect for Borders
    //public RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        float Min = 10f;
        float Max = 40f;
        float[] startTimes = new float[7];

        for (int i = 0; i < startTimes.Length; i++)
        {
            startTimes[i] = UnityEngine.Random.Range(Min, Max);
            //Debug.Log("Start " + i + ": " + startTimes[i]);

        }

        //add possible Items to List
        prefabList.Add(itemBirdIncrease);
        prefabList.Add(itemBirdDecrease);
        prefabList.Add(itemBirdNormalise);
        prefabList.Add(itemSpeedUp);
        prefabList.Add(itemSpeedDown);
        prefabList.Add(itemInvulnerable);
        prefabList.Add(itemAddLife);


        // Spawn items every 4 seconds, starting in 2
        InvokeRepeating("SpawnBirdIncrease", startTimes[0], UnityEngine.Random.Range(BirdIncreaseFrequency[0], BirdIncreaseFrequency[1]));
        InvokeRepeating("SpawnBirdDecrease", startTimes[1], UnityEngine.Random.Range(BirdDecreaseFrequency[0], BirdDecreaseFrequency[1]));
        InvokeRepeating("SpawnBirdNormalise", startTimes[2], UnityEngine.Random.Range(BirdNormaliseFrequency[0], BirdNormaliseFrequency[1]));
        InvokeRepeating("SpawnSpeedUp", startTimes[3], UnityEngine.Random.Range(SpeedUpFrequency[0], SpeedUpFrequency[1]));
        InvokeRepeating("SpawnSpeedDown", startTimes[4], UnityEngine.Random.Range(SpeedDownFrequency[0], SpeedDownFrequency[1]));
        InvokeRepeating("SpawnInvulnerable", startTimes[5], UnityEngine.Random.Range(InvulnerableFrequency[0], InvulnerableFrequency[1]));
        InvokeRepeating("SpawnAddLife", startTimes[6], UnityEngine.Random.Range(AddLifeFrequency[0], AddLifeFrequency[1]));


        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    //if GameOver, stop Spawning
    void Update()
    {
        // Cancel all Invoke calls
        if (GameController.instance.gameOver == true)
        {
            CancelInvoke();
        }
    }

    // Spawn one item
    void SpawnBirdIncrease()
    {
        spawnVector();
        bool usefullItem = true;
        int prefabIndex = 0;
        if (GameController.instance.sizeState == 3)
        {
            usefullItem = false;
        }
        if (usefullItem == true && justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */   
        }
    }
    void SpawnBirdDecrease()
    {
        spawnVector();
        int prefabIndex = 1;
        bool usefullItem = true;
        if (GameController.instance.sizeState == 1)
        {
            usefullItem = false;
        }
        if (usefullItem == true && justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */   
        }
    }
    void SpawnBirdNormalise()
    {
        spawnVector();
        int prefabIndex = 2;
        bool usefullItem = true;
        if (GameController.instance.sizeState == 2)
        {
            usefullItem = false;
        }
        if (usefullItem == true && justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */   
        }
    }
    void SpawnSpeedUp()
    {
        spawnVector();
        int prefabIndex = 3;
        if (justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */   
        }
        else
        {
            StartCoroutine(spawnLater(prefabIndex));
        }
    }
    void SpawnSpeedDown()
    {
        spawnVector();
        int prefabIndex = 4;
        if (justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */  
        }
        else
        {
            StartCoroutine(spawnLater(prefabIndex));
        }
    }

    void SpawnInvulnerable()
    {
        spawnVector();
        int prefabIndex = 5;
        if (justSpawned == false)
        {
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */  
        }
        else
        {
            StartCoroutine(spawnLater(prefabIndex));
        }
    }

    void SpawnAddLife()
    {
        spawnVector();
        int prefabIndex = 6;
        if (GameController.instance.life >= 5)
        {
            prefabIndex = 5;
        }
        if (justSpawned == false)
        {
            if (prefabIndex == 5)
            {
                Debug.Log("Max Life - Schild statt Leben");
            }
            StartCoroutine(itemJustSpawned());
            Instantiate(prefabList[prefabIndex], new Vector2(x, y), Quaternion.identity); // default rotation */  
        }
        else
        {
            StartCoroutine(spawnLater(prefabIndex));
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
//            Debug.Log("new vector " + vectorOK);
            // instead of line 92:
            vectorOK = true;
        }
    }

    private IEnumerator itemJustSpawned()
    {
        justSpawned = true;
        yield return new WaitForSeconds(1f);
        justSpawned = false;
        yield return null;
    }

    private IEnumerator spawnLater(int i)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1.1f, 3f));
        if (justSpawned == false)
        {
            Instantiate(prefabList[i], new Vector2(x, y), Quaternion.identity); // default rotation */   
            StartCoroutine(itemJustSpawned());
        }
        else
        {
            //Debug.Log("Item zerstört");
        }
        yield return null;
    }
}



