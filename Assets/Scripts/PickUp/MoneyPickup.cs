using DG.Tweening;
using UnityEngine;

public class MoneyPickup : BasePickup
{
    [SerializeField] private int moneyAmount = 2;

    private void Awake()
    {
         transform.DORotate(new Vector3(0, 360, 0), 20f, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    public override void OnPickup(PlayerMoney playerMoney)
    {
        playerMoney.AddMoney(moneyAmount);
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
