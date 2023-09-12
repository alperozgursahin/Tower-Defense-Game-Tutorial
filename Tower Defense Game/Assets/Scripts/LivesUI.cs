using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}
