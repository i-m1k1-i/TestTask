using UnityEngine;

[RequireComponent(typeof(PlayerMoney))]
public class MoneyChangeEffects : MonoBehaviour
{
    [SerializeField] private AudioClip getMoneySound;
    [SerializeField] private AudioClip loseMoneySound;

    private PlayerMoney playerMoney;

    private void OnEnable()
    {
        playerMoney = GetComponent<PlayerMoney>();
        if (playerMoney != null)
        {
            playerMoney.MoneyAdded += OnMoneyAdded;
            playerMoney.MoneyRemoved += OnMoneyRemoved;
        }
    }

    private void OnMoneyAdded(int amount)
    {
        if (getMoneySound != null)
        {
            AudioEffectsManager.Instance.PlayClip(getMoneySound, transform.position);
        }
    }

    private void OnMoneyRemoved(int amount)
    {
        if (loseMoneySound != null)
        {
            AudioEffectsManager.Instance.PlayClip(loseMoneySound, transform.position);
        }
    }

    private void OnDisable()
    {
        if (playerMoney != null)
        {
            playerMoney.MoneyAdded -= OnMoneyAdded;
            playerMoney.MoneyRemoved -= OnMoneyRemoved;
        }
    }
}
