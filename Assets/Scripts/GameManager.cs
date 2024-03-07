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
    [HideInInspector]
    public bool gameStarted = false;
    [SerializeField]
    private HeartBar heartBar;
    [HideInInspector]
    public bool isGameOver = false;


    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void Start()
    {
        gamePanel.SetActive(false);
        startPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            gameStarted = true;
        }
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
            isGameOver = false;
            Time.timeScale = 0;
        }
    }
}
