using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string mainLevel = "MainLevel";
    public string controls = "Controls";
    public string mainMenu = "MainMenu";
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(mainLevel);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void Controls()
    {
        sceneFader.FadeTo(controls);
    }

    public void BackToMenu()
    {
        sceneFader.FadeTo(mainMenu);
    }
}
