using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    private int columnPoolSize = 15;
    public GameObject columnPrefab;
    public float columnMin = -1.5f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float spawXPosition = 10f;
    private int currentColumn = 0;

    private float speedYPosition = 0.5f;
    private float deltaYPosition = 2f;
    
    private float distanceToLastObstacle;

 
    private float minGapSize = 0.5f;
    private float maxGapSize = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

       
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);

           
        }

        for (int i = 0; i < columnPoolSize; i++) {
         
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
                
                float rndGap = Random.Range(0f, minGapSize);
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY + rndGap);

            }
            else
            {
                float rndGap = Random.Range(0f, maxGapSize);
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY - rndGap);
            }




            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }

         
        }
        
    }

    //for testing pls do not remove
    private float GapSize(GameObject current)
    {
        float gapsize;

        float lowerColumY = current.transform.GetChild(0).transform.position.y;
      
        float upperColY = current.transform.GetChild(1).transform.position.y - 10.24f;

        gapsize = Mathf.Abs(lowerColumY - upperColY);

        return gapsize;
    }



}
