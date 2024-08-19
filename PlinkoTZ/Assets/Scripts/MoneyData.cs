using UnityEngine;

public class MoneyData : MonoBehaviour
{
    private float money = 3000.0f;
    private float bet = 0.4f;

    private const string MoneyKey = "Money";

    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            PlayerPrefs.SetFloat(MoneyKey, money);
            PlayerPrefs.Save();
        }
    }

    public float Bet
    {
        get { return bet; }
        set { bet = value; }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            money = PlayerPrefs.GetFloat(MoneyKey);
        }
    }

    public void AddMoney(TargetMultiplier targetMultiplier)
    {
        float multiplier = targetMultiplier.GetMultiplier();
        Money += Bet * multiplier;
        Debug.Log($"Деньги добавлены: {money}. Bet: {bet}, Multiplier: {multiplier}");
        GameUI.instance.DisplayUI();
    }

    public void SubtractMoney()
    {
        Money -= bet; 
    }

    public void AddBet(float value)
    {
        bet += value;
        GameUI.instance.DisplayUI();
    }

    public void SubtractBet(float value)
    {
        bet = Mathf.Max(0, bet - value);
        GameUI.instance.DisplayUI();
    }
}
