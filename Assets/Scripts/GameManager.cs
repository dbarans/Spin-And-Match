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


    private void Awake()
    {
        Application.targetFrameRate = 120;
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
