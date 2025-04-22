using System;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    public event Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Triggered?.Invoke();
        }
    }
}
