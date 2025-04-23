using UnityEngine;

[RequireComponent(typeof(PlayerMoney))]
public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private AudioClip getMoneySound;
    [SerializeField] private AudioClip loseMoneySound;
    [SerializeField] private AudioClip transformationSound;

    private PlayerMoney playerMoney;
    private Player player;

    private void OnEnable()
    {
        player = GetComponent<Player>();
        playerMoney = GetComponent<PlayerMoney>();
        player.Transformated += OnTransformated;
        playerMoney.MoneyAdded += OnMoneyAdded;
        playerMoney.MoneyRemoved += OnMoneyRemoved;
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

    private void OnTransformated()
    {
        if (transformationSound != null)
        {
            AudioEffectsManager.Instance.PlayClip(transformationSound, transform.position);
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
