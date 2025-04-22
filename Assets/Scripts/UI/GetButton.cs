using UnityEngine;
using UnityEngine.UI;

public class GetButton : MonoBehaviour
{
    [SerializeField] private GameObject SelfCanvas;
    [SerializeField] private GameObject NextButtonCanvas;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Player player = FindAnyObjectByType<Player>();
        player.GetComponent<PlayerMoney>().ClaimCollectedMoney(player.RichLevel);
        SelfCanvas.SetActive(false);
        NextButtonCanvas.SetActive(true);
    }
}
