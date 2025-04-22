using ButchersGames;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        LevelManager.Default.NextLevel();
    }
}
