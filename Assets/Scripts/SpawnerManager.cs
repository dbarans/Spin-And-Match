using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<SpawnObstacleScript> spawners = new List<SpawnObstacleScript>();
    private float spawnTimer = 0f;
    [SerializeField]
    private float spawnInterval = 1.5f;


    private void Awake()
    {
        
        GameObject[] spawnerObjects = GameObject.FindGameObjectsWithTag("Spawner");

        foreach (GameObject spawnerObject in spawnerObjects)
        {
            SpawnObstacleScript spawnerScript = spawnerObject.GetComponent<SpawnObstacleScript>();
            if (spawnerScript != null)
            {
                AddSpawner(spawnerScript);
            }
            else
            {
                Debug.LogWarning("There is no spawner!!");
            }
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;
        }
    }
    public void AddSpawner(SpawnObstacleScript spawner)
    {
        spawners.Add(spawner);
    }

    public void SpawnObstacle()
    {
        Debug.Log("Spawning obstacle");
        int randomIndex = Random.Range(0, spawners.Count);
        spawners[randomIndex].SpawnObstacle();
    }
}
