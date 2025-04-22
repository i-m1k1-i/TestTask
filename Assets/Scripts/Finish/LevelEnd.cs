using System;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public static event Action LevelCompleted;

    [SerializeField] private RichLevel richLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (richLevel >= player.RichLevel) 
            {
                LevelCompleted?.Invoke();
            }
        }
    }
}
