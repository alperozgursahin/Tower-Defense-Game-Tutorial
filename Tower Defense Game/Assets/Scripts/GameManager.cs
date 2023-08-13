using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isGameFinished = false;
    void Update()
    {
        if (isGameFinished) return;

        if (PlayerStats.Lives <= 0 )
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");
        isGameFinished = true;
    }
}
