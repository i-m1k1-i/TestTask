using UnityEngine;

public class ChoiceDoor : MonoBehaviour
{
    [SerializeField] private ChoiceDoorTrigger trigger;
    [SerializeField] private int moneyAmount;
    [SerializeField] private bool addMoney;

    private void Awake()
    {
        trigger.DoorTriggered += OnDoorTriggered;
    }

    private void OnDoorTriggered(PlayerMoney playerMoney)
    {
        if (addMoney)
        {
            playerMoney.AddMoney(moneyAmount);
        }
        else
        {
            playerMoney.RemoveMoney(moneyAmount);
        }
    }
}
