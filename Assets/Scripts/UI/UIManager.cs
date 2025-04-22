using ButchersGames;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject menuUI;


    private void Awake()
    {
        EnableMenu();
    }

    private void OnEnable()
    {
        LevelManager.Default.OnLevelStarted += EnableGame;
        LevelManager.Default.OnLevelLoaded += EnableMenu;
        LevelEnd.LevelCompleted += EnableWin;
    }

    private void EnableMenu()
    {
        gameUI.SetActive(false);
        winUI.SetActive(false);
        menuUI.SetActive(true);
    }

    private void EnableGame()
    {
        gameUI.SetActive(true);
        winUI.SetActive(false);
        menuUI.SetActive(false);
    }

    private void EnableWin()
    {
        gameUI.SetActive(false);
        winUI.SetActive(true);
        menuUI.SetActive(false);
    }
}
