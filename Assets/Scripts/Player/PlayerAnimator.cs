using ButchersGames;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string IdleTrigger = "Idle"; 
    const string WalkTrigger = "Walk";
    const string DanceTrigger = "Dance";
    const string TransformationTrigger = "Transformation";

    private Animator animator;
    private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        LevelManager.Default.OnLevelLoaded += StandIdle;
        LevelManager.Default.OnLevelStarted += StartWalking;
        LevelEnd.LevelCompleted += StartDancing;
        player.Transformated += Transformation;
    }

    private void StartWalking()
    {
        animator.SetTrigger(WalkTrigger);
    }

    private void StartDancing()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        animator.SetTrigger(DanceTrigger);
    }

    private void StandIdle()
    {
        animator.SetTrigger(IdleTrigger);
    }

    private void Transformation()
    {
        animator.SetTrigger(TransformationTrigger);
    }

    private void OnDisable()
    {
        LevelManager.Default.OnLevelStarted -= StartWalking;
        LevelEnd.LevelCompleted -= StartDancing;
        LevelManager.Default.OnLevelLoaded -= StandIdle;
    }
}
