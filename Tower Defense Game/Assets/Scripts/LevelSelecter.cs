using UnityEngine;

public class LevelSelecter : MonoBehaviour
{

    public SceneFader fader;

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

}
