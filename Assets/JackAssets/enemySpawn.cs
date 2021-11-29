using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject playerObject;
    Vector3 spawnPos;
    //Vector3 enemySpawnRot;
    int spawnning;
    int difficulty;
    int difficultyPlus;
    
    // Start is called before the first frame update
    void Start()
    {
 
            //< "Interaction Test (Script)" > ().speed;

        difficulty = 5;
        spawnning = 0;
        difficultyPlus = 0;
        spawnEnemy();
    /*    for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            // Instantiate(enemyPrefab, playerObject.transform.position + Vector3(1,0,1) * Random.Range(-15, 15), Quaternion.identity);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        } */
    }

    void spawnEnemy()
    {
       // enemySpawnRot = new Vector3(-90, 0, 0);
        Quaternion enemySpawnRot = Quaternion.Euler(-90, 0, 0); //enemy spawn rot in quanternion instead of vector3
        spawnPos = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
            // Instantiate(enemyPrefab, playerObject.transform.position + Vector3(1,0,1) * Random.Range(-15, 15), Quaternion.identity);
            Instantiate(enemyPrefab, spawnPos, enemySpawnRot);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(Time.time) % difficulty == 0)
        {
            spawnning += 1;
            if (spawnning % 100 == 0)
            {
                spawnEnemy();
            }
        }

        if(Mathf.Round(Time.time) % 30 == 0)
        {
            difficultyPlus += 1;
            if (difficultyPlus % 100 ==0 && difficulty >= 1)
            {
                difficulty -= 1;
            }
        }
        //Debug.Log(Time.captureFramerate);
    }
}
