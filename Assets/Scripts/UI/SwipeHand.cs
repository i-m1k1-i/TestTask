using UnityEngine;
using DG.Tweening;

public class SwipeHand : MonoBehaviour
{
    [SerializeField] private float endValue = 240f;

    private void Start()
    {
        transform.DOLocalMoveX(endValue, 0.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
