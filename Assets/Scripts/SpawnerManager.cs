using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<SpawnObstacleScript> spawners = new List<SpawnObstacleScript>();


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
    public void AddSpawner(SpawnObstacleScript spawner)
    {
        spawners.Add(spawner);
    }
}
