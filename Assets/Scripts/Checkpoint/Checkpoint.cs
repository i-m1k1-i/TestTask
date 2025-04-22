using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private CheckpointTrigger trigger;
    [SerializeField] private CheckpointEffects effects;

    private void OnEnable()
    {
        trigger.CheckpointReached += OnCheckpointReached;
    }

    private void OnCheckpointReached()
    {
        effects.CheckpointReachedEffectsPlay();
    }

    private void OnDisable()
    {
        trigger.CheckpointReached -= OnCheckpointReached;
    }
}
