using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 15;
    public GameObject columnPrefab;
    public float columnMin = -2f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float spawXPosition = 10f;
    private int currentColumn = 0;

    
    private float distanceToLastObstacle;

    
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector2(spawXPosition, spawnYPosition);
        currentColumn++;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        int correctIndex;
        if (currentColumn == 0)
        {
            correctIndex = columnPoolSize-1;
        }
        else
        {
            correctIndex = currentColumn - 1;
        }

        distanceToLastObstacle = spawXPosition - columns[correctIndex].transform.position.x;
      
      

        if(GameController.instance.gameOver == false && distanceToLastObstacle > GameController.instance.obstacleSpawnDistance)
        {
            Debug.Log("spawn");
           
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
