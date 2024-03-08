using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int points = 0;
    [HideInInspector]
    public int health = 3;
    [SerializeField]
    private TextMeshProUGUI pointsText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject startPanel;
    [SerializeField]
    private GameObject endPanel;
    [HideInInspector]
    public bool gameStarted = false;
    [SerializeField]
    private HeartBar heartBar;
    [HideInInspector]
    public bool isGameOver = false;
    [SerializeField]
    private SpawnerManager spawnerManager;


    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void Start()
    {
        gamePanel.SetActive(false);
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            gameStarted = true;
        }
        if(isGameOver && Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            gamePanel.SetActive(false);
        }
        spawnerManager.UpdateSpawnerInterval(); 
    }

    public void SameColorCollision()
    {
        points++;
        pointsText.text = "Points: " + points;
    }
    public void DifferentColorCollision()
    {
        health--;
        heartBar.UpdateHearts();
        if (health < 1)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        endPanel.SetActive(true);
        gamePanel.SetActive(false);
    }   
    

    
}
