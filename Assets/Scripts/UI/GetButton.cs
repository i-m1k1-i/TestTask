using ButchersGames;
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
        LevelManager.Default.OnLevelLoaded += OnLevelLoaded;
    }

    private void OnButtonClick()
    {
        Player player = FindAnyObjectByType<Player>();
        PlayerMoney playerMoney = player.GetComponent<PlayerMoney>();
        playerMoney.ClaimCollectedMoney(player.RichLevel);

        SelfCanvas.SetActive(false);
        NextButtonCanvas.SetActive(true);
    }

    private void OnLevelLoaded()
    {
        SelfCanvas.SetActive(true);
        NextButtonCanvas.SetActive(false); 
    }
}
