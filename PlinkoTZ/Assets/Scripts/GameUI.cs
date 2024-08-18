using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI betText;

    [SerializeField] private MoneyData moneyData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DisplayUI();
    }
    private void Update()
    {
        DisplayUI();
    }

    public void DisplayUI()
    {
        moneyText.text = moneyData.Money.ToString();
        betText.text = moneyData.Bet.ToString();
        Debug.Log(moneyData.Money);
        Debug.Log(moneyData.Bet);
    }
}
