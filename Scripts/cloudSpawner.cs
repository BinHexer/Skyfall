using UnityEngine;
using System.Collections;

public class cloudSpawner : MonoBehaviour
{

    #region ### public fields #########################################################################################
    #endregion

    public GameObject[] clouds;
    public float spawnTimeMax;
    public float spawnTimeMin;
   
   


    #region ### private fields ########################################################################################
    #endregion

    private int nextCloud;
    private float elapsedTime;
    private float spawnTime;

    // Use this for initialization
    void Start()
    {

        int nextCloud = GenerateRandomCloudIndex();
        Debug.Log(nextCloud);

        // set first time until the cloud will spawn
        spawnTime = SetSpawnTime(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {

        // store the elapsed time
        elapsedTime += Time.deltaTime;
        //Debug.Log(elapsedTime);

        if (elapsedTime > spawnTime)
        {
            elapsedTime = 0;
            spawnTime = SetSpawnTime(spawnTimeMin, spawnTimeMax);
            Debug.Log("Spawn");

            GameObject cloud = (GameObject)Instantiate(clouds[nextCloud], new Vector3(GenerateRandomXPosition(7), -12, SetPlane()), this.transform.rotation);
            cloudMover cloudMoverScript = (cloudMover)cloud.GetComponent("cloudMover");


            
            
            Debug.Log(SetPlane());


            nextCloud = GenerateRandomCloudIndex();
            

        }
    }

    #region ### Custom Functions ######################################################################################
    #endregion

    int GenerateRandomCloudIndex()
    {
        return Random.Range(0, clouds.Length);
    }

    float SetSpawnTime(float min, float max)
    {
        return Random.Range(min, max);
    }

    int GenerateRandomXPosition(int border)
    {
        return Random.Range(-border, border+1);
    }

    int SetPlane()
    {
        return Random.Range(-3, 0);
    }
}
