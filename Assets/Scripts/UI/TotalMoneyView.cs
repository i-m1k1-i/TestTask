using TMPro;
using UnityEngine;

public class TotalMoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalMoneyTMP;

    public void UpdateTotalMoney()
    {
        totalMoneyTMP.text = PlayerMoney.TotalMoney.ToString();
    }

    private void Update()
    {
        UpdateTotalMoney();
    }
}
