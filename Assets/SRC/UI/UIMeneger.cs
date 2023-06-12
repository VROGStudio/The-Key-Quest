using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage the Timer UI
public class UIMeneger : MonoBehaviour
{
    [SerializeField] private GameObject timer;

    private void Start()
    {
        newEvents.Sub("Start Game", StartGame);
        newEvents.Sub("Game Over", GameOver);
        timer.SetActive(false);
    }

    private bool StartGame()
    {
        timer.SetActive(true);
        return true;
    }

    private bool GameOver()
    {
        timer.SetActive(false);
        return false;
    }
}
