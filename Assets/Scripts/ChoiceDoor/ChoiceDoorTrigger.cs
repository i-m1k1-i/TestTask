using System;
using UnityEngine;

public class ChoiceDoorTrigger : MonoBehaviour
{
    public event Action<PlayerMoney> DoorTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMoney>(out PlayerMoney playerMoney))
        {
            DoorTriggered?.Invoke(playerMoney);
        }
    }
}