using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public const string TotalMoney_PrefsKey = "Total Money";

    public static int TotalMoney { get { return PlayerPrefs.GetInt(TotalMoney_PrefsKey); } private set { PlayerPrefs.SetInt(TotalMoney_PrefsKey, value); } }
    public int CollectedOnLevel { get; private set; } = 40;

    private readonly Dictionary<RichLevel, int> richLevelMultiplier = new Dictionary<RichLevel, int>()
    {
        { RichLevel.Hobo, 1},
        { RichLevel.Poor, 2},
        { RichLevel.Middle, 3},
        { RichLevel.Rich, 4},
        { RichLevel.SuperRich, 5}
    };

    public event Action<int> MoneyAdded;
    public event Action<int> MoneyRemoved;

    public void AddMoney(int amount)
    {
        CollectedOnLevel += amount;
        Debug.Log("Money added: " + amount);
        MoneyAdded?.Invoke(amount);
    }

    public void RemoveMoney(int amount)
    {
        CollectedOnLevel -= amount;
        MoneyRemoved?.Invoke(amount);
        Debug.Log("Money removed: " + amount);
    }

    public void ResetLevelMoney()
    {
        CollectedOnLevel = 40;
    }

    public void ClaimCollectedMoney(RichLevel richLevel)
    {
        int earned = CollectedOnLevel;
        int multiplier = richLevelMultiplier[richLevel];
        CollectedOnLevel = 0;
        TotalMoney += earned * multiplier;
    }
}
