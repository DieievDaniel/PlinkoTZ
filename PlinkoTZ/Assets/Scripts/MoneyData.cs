using UnityEngine;

public class MoneyData : MonoBehaviour
{
    private float money = 3000.0f;
    private float bet = 0.4f;

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    public float Bet
    {
        get { return bet; }
        set { bet = value; }
    }

    public void AddMoney(TargetMultiplier targetMultiplier)
    {
        float multiplier = targetMultiplier.GetMultiplier();
        money += bet * multiplier;
        Debug.Log($"Деньги добавлены: {money}. Bet: {bet}, Multiplier: {multiplier}");
        GameUI.instance.DisplayUI();
    }

    public void SubtractMoney()
    {
        money -= bet;
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
