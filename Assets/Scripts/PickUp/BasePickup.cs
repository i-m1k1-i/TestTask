using System;
using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    public event Action<BasePickup> PickedUp;

    public abstract void OnPickup(PlayerMoney playerMoney);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMoney>(out PlayerMoney playerMoney))
        {
            OnPickup(playerMoney);
            PickedUp?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
