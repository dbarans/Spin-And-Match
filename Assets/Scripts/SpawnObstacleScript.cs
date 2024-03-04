using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
