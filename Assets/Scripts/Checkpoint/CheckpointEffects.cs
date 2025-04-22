using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CheckpointEffects : MonoBehaviour
{
    const string Check_Trigger = "Check";

    [SerializeField] private AudioClip audioClip;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void CheckpointReachedEffectsPlay()
    {
        animator.SetTrigger(Check_Trigger);
        AudioEffectsManager.Instance.PlayClip(audioClip, transform.position);
    }
}
