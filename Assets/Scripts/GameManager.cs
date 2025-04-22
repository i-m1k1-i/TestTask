using UnityEngine;
using ButchersGames;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputReader input;

    private bool started = false;

    private void OnEnable()
    {
        LevelManager.Default.OnLevelLoaded += OnLevelLoaded;
    }

    private void Update()
    {
        if (started)
            return;

        if (input.MoveInput != 0)
        {
            LevelManager.Default.StartLevel();
            started = true;
        }
    }

    private void OnLevelLoaded()
    {
        started = false;
    }

    private void OnDisable()
    {
        LevelManager.Default.OnLevelLoaded -= OnLevelLoaded;
    }
}
