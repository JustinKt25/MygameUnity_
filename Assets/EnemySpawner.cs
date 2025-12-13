using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public float initialSpawnInterval = 2f; 
    public float minSpawnInterval = 0.5f;   
    public float difficultyIncreaseRate = 0.05f; 

    private float currentSpawnInterval;
    private float nextSpawnTime = 0f;

    
    public float spawnDistance = 15f; 

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating("SpawnEnemy", initialSpawnInterval, initialSpawnInterval);
    }

    void Update()
    {
        
        if (currentSpawnInterval > minSpawnInterval)
        {
            currentSpawnInterval -= Time.deltaTime * difficultyIncreaseRate;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval); 

            
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", currentSpawnInterval, currentSpawnInterval);
        }
    }

    void SpawnEnemy()
    {
        

        
        int side = Random.Range(0, 4);
        Vector3 spawnPosition = Vector3.zero;

        
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        switch (side)
        {
            case 0: 
                spawnPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), playerPos.y + spawnDistance, 0);
                break;
            case 1: 
                spawnPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), playerPos.y - spawnDistance, 0);
                break;
            case 2: 
                spawnPosition = new Vector3(playerPos.x - spawnDistance, Random.Range(-spawnDistance, spawnDistance), 0);
                break;
            case 3: 
                spawnPosition = new Vector3(playerPos.x + spawnDistance, Random.Range(-spawnDistance, spawnDistance), 0);
                break;
        }

        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
