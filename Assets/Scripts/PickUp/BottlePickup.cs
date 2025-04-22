using UnityEngine;

public class BottlePickup : BasePickup
{
    [SerializeField] private int penaltyAmount = 20;

    public override void OnPickup(PlayerMoney playerMoney)
    {
        playerMoney.RemoveMoney(penaltyAmount);
    }
}
