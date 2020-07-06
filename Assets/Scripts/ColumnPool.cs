using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 150;
    public GameObject columnPrefab;
    public float columnMin = -2f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float spawXPosition = 10f;
    private int currentColumn = 0;

    private float speedYPosition = 0.5f;
    private float deltaYPosition = 2f;
    
    private float distanceToLastObstacle;

 
    private float minGapSize = 0.2f;
    private float maxGapSize = 1f;


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
           // Debug.Log("spawn");
           
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawXPosition, spawnYPosition);




            //change Gap between obstacle

            float curLocalY = columns[currentColumn].transform.GetChild(0).transform.localPosition.y;
            var randomSmaller = Random.Range(0, 2);

            if( randomSmaller == 0)
            {
                float rndGap = Random.Range(0,minGapSize+1);
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY + rndGap);
            }
            else
            {
                float rndGap = Random.Range(0, maxGapSize + 1);
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY - rndGap);
            }


            //to activate the up and down movement
        



            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

        /* Idee, wie man die Columns bewegen kann
        foreach (GameObject column in columns)
        {
            float y = Mathf.PingPong(speedYPosition * Time.time, deltaYPosition);
            UnityEngine.Vector2 pos = new UnityEngine.Vector2(column.transform.position.x, y);
            column.transform.position = pos;
        }
        */

        
    }




}
