using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string controllersMenu = "ControllersMenu";
    public string mainMenu = "MainMenu";
    public string levelSelectMenu = "LevelSelect";
    public SceneFader sceneFader;

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene(controllersMenu);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LevelSelect()
    {
        sceneFader.FadeTo(levelSelectMenu);
    }
}
