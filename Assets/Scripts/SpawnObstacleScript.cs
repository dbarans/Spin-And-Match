using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    private SpawnerManager spawnerManager;

    private void Awake()
    {
        spawnerManager = FindObjectOfType<SpawnerManager>();
        spawnerManager.AddSpawner(this);
    }

    public void SpawnObstacle(Color color)
    {
        GameObject spawnedObstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        Renderer renderer = spawnedObstacle.GetComponent<Renderer>();
        renderer.material.color = color;
        
     }
}
