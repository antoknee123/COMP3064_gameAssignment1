using UnityEngine;
using System.Collections;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - controls enemy spawn behaviour 
public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyGO; // this is our enemy prefab
    float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start () {
        // spawns enemy every 5 secs
        InvokeRepeating("SpawnEnemy", 0f, 5f);
    }
	
	// Update is called once per frame
	void Update () {

    }
    void SpawnEnemy()
    {
        

        //instantiate an enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(5, Random.Range(-3, 3));

        //schedule when to spawn next enemy
       //SceduleNextEnemySpawn();


    }

    void SceduleNextEnemySpawn()
    {

        float spawnInSeconds;
       
        if (maxSpawnRateInSeconds > 1f)
        {

            //use a number between 1 and maxSpawnRateInSeconds
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);


        }

        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
    }

    //Function to increase the diffculty of the game
    void IncreaseSpawnRate()
    {

        if (maxSpawnRateInSeconds > 2f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");

    }
    //function to start enemy spawner
    public void ScheduleEnemySpawner()
    {
        //reset max spawn rate
        float maxSpawnRateInSeconds = 1f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn rate every 15 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 15f);


    }
    //Function to stop enemy spawn
    public void UnscheduleEnemySpawner()
    {

        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreasesSpawnRate");
    }
}
