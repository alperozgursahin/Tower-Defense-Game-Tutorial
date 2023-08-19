using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainLevel";
   public void Play()
   {
        SceneManager.LoadScene(levelToLoad);
   }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
