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

        if (moneyData == null)
        {
            Debug.LogError("MoneyData не инициализировано в GameUI");
        }
    }

    private void Start()
    {
        if (moneyData != null)
        {
            moneyData.Money = PlayerPrefs.GetFloat("Money", 3000.0f); 
            DisplayUI();
        }
    }

    public void DisplayUI()
    {
        if (moneyData != null)
        {
            moneyText.text = moneyData.Money.ToString();
            betText.text = moneyData.Bet.ToString();
            Debug.Log($"DisplayUI: Деньги: {moneyData.Money}, Ставка: {moneyData.Bet}");
        }
        else
        {
            Debug.LogError("MoneyData не инициализировано в DisplayUI");
        }
    }
}
