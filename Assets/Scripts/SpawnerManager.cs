using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<SpawnObstacleScript> spawners = new List<SpawnObstacleScript>();
    public List<Color> colors = new List<Color>();
    private float spawnTimer = 2f;
    public float spawnInterval = 1.5f;
    [SerializeField]
    private GameManager gameManager;
    private bool isSpawnerIntervalChanged = true;


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
        if (gameManager.gameStarted)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnObstacle();
                spawnTimer = 0f;
            }
        }

    }
    public void AddSpawner(SpawnObstacleScript spawner)
    {
        spawners.Add(spawner);
    }

    public void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, spawners.Count);
        Color color = RandomColor();
        spawners[randomIndex].SpawnObstacle(color);
    }

    private Color RandomColor()
    {
        Color color = colors[Random.Range(0, colors.Count)];
        return color;
    }

    public void UpdateSpawnerInterval()
    {
        int pointsToChangeInterval = 3;
        if (!isSpawnerIntervalChanged && gameManager.points % pointsToChangeInterval == 0)
        {
            if (spawnInterval > 1f)
            {
                spawnInterval -= 0.1f;
            }
            isSpawnerIntervalChanged = true;
        }
        if (isSpawnerIntervalChanged && gameManager.points % pointsToChangeInterval != 0)
        {
            isSpawnerIntervalChanged = false;
        }
    }
}
