using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool isGameOver;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFader sceneFader; 


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
        Debug.Log("LEVEL WON!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
