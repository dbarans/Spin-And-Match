using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject obstaclePrefab;

    void Start()
    {
        obstaclePrefab = GameObject.FindGameObjectWithTag("Obstacle");
    }

    public void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
