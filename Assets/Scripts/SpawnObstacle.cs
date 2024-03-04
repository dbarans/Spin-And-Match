using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    void Start()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
