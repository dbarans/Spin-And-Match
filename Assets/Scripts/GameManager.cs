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
    private TextMeshProUGUI healthText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject startPanel;
    [HideInInspector]
    public bool gameStarted = false;


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
        healthText.text = "Health: " + health;
        if (health < 1)
        {
            Debug.Log("Game Over");
        }
    }
}
