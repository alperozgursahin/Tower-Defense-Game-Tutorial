using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class LevelSelecter : MonoBehaviour
{

    public SceneFader fader;
    public Button[] levelButtons;

    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {   
            if (i + 1 > levelReached) 
                levelButtons[i].interactable = false;
            else if (i + 1 == levelReached)
                levelButtons[i].interactable = true;
            
        }
        
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelSelect");
    }

}
