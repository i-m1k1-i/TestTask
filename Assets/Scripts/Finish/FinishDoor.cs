using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinishDoor : MonoBehaviour
{
    const string OpenTrigger = "Open";

    [SerializeField] private AudioClip openSound;
    [SerializeField] private DoorOpenTrigger trigger;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        trigger.Triggered += OpenDoor;
    }

    private void OpenDoor()
    {
        AudioEffectsManager.Instance.PlayClip(openSound, transform.position);
        animator.SetTrigger(OpenTrigger);
    }

    private void OnDisable()
    {
        trigger.Triggered -= OpenDoor;
    }
}
