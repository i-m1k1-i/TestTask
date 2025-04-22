using System;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public event Action CheckpointReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointReached?.Invoke();
            Debug.Log("Checkpoint reached");
        }
    }
}
