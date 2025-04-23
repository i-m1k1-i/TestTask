using UnityEngine;
using ButchersGames;
using System;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private RichLevel richLevel;
    [SerializeField] private CinemachineFollow cinemachineFollow;

    private RichLevelSkin richLevelSkin;
    private PlayerMoney money;
    private PlayerSplineMover splineMover;

    public RichLevel RichLevel => richLevel;

    public event Action Transformated;
    public event Action Lost;

    private void Awake()
    {
        richLevelSkin = GetComponent<RichLevelSkin>();
        money = GetComponent<PlayerMoney>();
        splineMover = GetComponent<PlayerSplineMover>();

        splineMover.Stop();
        richLevelSkin.SetSkin(richLevel);
    }

    private void OnEnable()
    {
        LevelManager.Default.OnLevelStarted += OnLevelStarted;
        LevelEnd.LevelCompleted += OnLevelCompleleted;
        money.MoneyAdded += UpdateRichLevel;
        money.MoneyRemoved += UpdateRichLevel;
    }

    private void OnLevelCompleleted()
    {
        cinemachineFollow.enabled = false;
        splineMover.Stop();
    }

    private void OnLevelStarted()
    {
        money.ResetLevelMoney();
        splineMover.Go();
    }

    private void UpdateRichLevel(int _)
    {
        Array levels = RichLevel.GetValues(typeof(RichLevel));
        for (int i = levels.Length - 1; i >= 0; i--)
        {
            var level = levels.GetValue(i);
            Debug.Log("Rich level: " + level);
            if (money.CollectedOnLevel >= (int)level)
            {
                if (richLevel == (RichLevel)level)
                    return;
                richLevel = (RichLevel)level;
                richLevelSkin.SetSkin(richLevel);
                Transformated?.Invoke();
                break;
            }
        }
    }

    private void OnDisable()
    {
        LevelManager.Default.OnLevelStarted -= money.ResetLevelMoney;
        LevelEnd.LevelCompleted -= OnLevelCompleleted;
        money.MoneyAdded -= UpdateRichLevel;
        money.MoneyRemoved -= UpdateRichLevel;
    }
}
