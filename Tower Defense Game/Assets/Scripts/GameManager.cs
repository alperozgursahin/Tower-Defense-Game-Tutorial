using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool isGameOver;
    public GameObject completeLevelUI;


    private void Start()
    {
        PlayerStats.Rounds = 0;
        isGameOver = false;
    }
    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0 )
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        
        isGameOver = true;
        gameOverUI.SetActive(true);

    }

    public void WinLevel()
    {
        isGameOver = true; gameOverUI.SetActive(false);
        completeLevelUI.SetActive(true);
    }
}
