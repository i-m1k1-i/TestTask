using ButchersGames;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyNumber;
    [SerializeField] private TextMeshProUGUI levelNumber;
    [SerializeField] private PlayerMoney playerMoney;

    private void OnEnable()
    {
        playerMoney = FindAnyObjectByType<PlayerMoney>();
        LevelManager.Default.OnLevelStarted += UpdateLevel;
    }

    private void Start()
    {
        UpdateLevel();
    }

    private void Update()
    {
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        int money = playerMoney.CollectedOnLevel;
        moneyNumber.text = money.ToString();
    }

    public void UpdateLevel()
    {
        int level = LevelManager.CurrentLevel;
        levelNumber.text = level.ToString();
    }
}
