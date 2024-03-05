using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[HideInInspector]
    public int points = 0;
   // [HideInInspector]
    public int health = 3;


    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    public void SameColorCollision()
    {
        points++;
    }
    public void DifferentColorCollision()
    {
        health--;
    }
}
