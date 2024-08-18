using UnityEngine;

public class TargetBoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TargetBox"))
        {
            TargetMultiplier targetMultiplier = collision.gameObject.GetComponent<TargetMultiplier>();
            MoneyData moneyData = GetComponent<MoneyData>();

            if (targetMultiplier != null && moneyData != null)
            {
                moneyData.AddMoney(targetMultiplier);
                Debug.Log("Money added with multiplier: " + targetMultiplier.GetMultiplier());
            }

            BallPool.Instance.ReturnBall(gameObject);
        }
    }
}
