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
    [SerializeField]
    private TextMeshProUGUI endScoreText;
    [SerializeField]
    private Data data;


    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void Start()
    {   if (data.isGameRestarted)
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            endPanel.SetActive(false);
        }
        else
        {
            startPanel.SetActive(true);
            gamePanel.SetActive(false);
            endPanel.SetActive(false);
        }
        Time.timeScale = 1;
        
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
            data.isGameRestarted = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
        endScoreText.text = "Score: " + points;

    }
   
    
}
