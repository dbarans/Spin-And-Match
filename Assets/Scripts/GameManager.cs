using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    private bool canClick = false;


    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void Start()
    {   if (data.isGameRestarted)               //after restart
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            endPanel.SetActive(false);
        }
        else                               // first start of the game
        {
            startPanel.SetActive(true);
            gamePanel.SetActive(false);
            endPanel.SetActive(false);
        }
        Time.timeScale = 1;
        
    }

    private void Update()
    {
        if (Input.anyKeyDown && !gameStarted)  // start of the game
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            gameStarted = true;
        }
      
        if(isGameOver && Input.anyKeyDown && canClick)      // restart of the game
        {
            data.isGameRestarted = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        spawnerManager.UpdateSpawnerInterval();  // update the interval of the spawner
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
        StartCoroutine(DelayRestart(1));

    }
    private IEnumerator DelayRestart(float seconds)
    {
        canClick = false;
        yield return new WaitForSecondsRealtime(seconds);
        canClick = true;
    }


}
