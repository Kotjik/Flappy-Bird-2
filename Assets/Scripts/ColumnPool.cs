using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    private int columnPoolSize = 15;
    public GameObject columnPrefab;

    public GameObject treeObstacle;
    public GameObject cageObstacle;
    public GameObject pileObstacle;
    public GameObject pile1Obstacle;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float spawXPosition = 10f;
    private int currentColumn;

    private float distanceToLastObstacle;


    //y position
    private float colMinPile1 = 1f;
    private float colMaxPile1 = 4f;

    private float colMinPile0 = 1f;
    private float colMaxPile0 = 4f;

    private float spawnYPosition;




    // Start is called before the first frame update
    void Start()
    {

       
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            if (i%3 == 0)
            {
                columns[i] = (GameObject)Instantiate(pile1Obstacle, objectPoolPosition, Quaternion.identity);
            }
            else
            {
                columns[i] = (GameObject)Instantiate(pileObstacle, objectPoolPosition, Quaternion.identity);
            }
         

           
        }

    
        if(columns[currentColumn].tag == "1")
        {
            spawnYPosition = Random.Range(colMinPile1, colMaxPile1);
        }else if (columns[currentColumn].tag == "0")
        {
            spawnYPosition = Random.Range(colMinPile0, colMaxPile0);
        }
   
        columns[currentColumn].transform.position = new Vector2(spawXPosition, spawnYPosition);
        currentColumn++;

        
    }

 
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
  


            if (columns[currentColumn].tag == "1")
            {
                spawnYPosition = Random.Range(colMinPile1, colMaxPile1);
            }
            else if (columns[currentColumn].tag == "0")
            {
                spawnYPosition = Random.Range(colMinPile0, colMaxPile0);
            }




            // reset child position of the obstacle
            if(columns[currentColumn].tag == "0")
            {
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, 2.503f);
              
            }
            else
            {
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, -7.759f);

            }
           


            //spawn obstacle
            columns[currentColumn].transform.position = new Vector2(spawXPosition, spawnYPosition);


            //change Gap between obstacle
            float curLocalY = columns[currentColumn].transform.GetChild(0).transform.localPosition.y;
           

            if(columns[currentColumn].tag == "0")
            {
                var randomSmaller = Random.Range(0, 2);
                float rndGap;

                if (randomSmaller == 1)
                {
                    //make gap bigger
                    rndGap = Random.Range(0.0f, -2.0f);
                }   
                else {
                    //make gap smaller
                    rndGap = Random.Range(0f, 0.7f);
                }

                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY - rndGap);
            }

            if (columns[currentColumn].tag == "1")
            {
                var randomSmaller = Random.Range(0, 2);
                float rndGap;

                if (randomSmaller == 1)
                {
                    //make bigger
                    rndGap = Random.Range(0.0f, 2.0f);
                }
                else
                {
                    //make smaller
                    rndGap = Random.Range(0f, -0.7f);

                }
                columns[currentColumn].transform.GetChild(0).transform.localPosition = new Vector2(0, curLocalY - rndGap);
            }


            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }

        }  
    }
}
