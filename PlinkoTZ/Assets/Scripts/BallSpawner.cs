using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private MoneyData moneyData;

    public void SpawnBall()
    {
        if (BallPool.Instance != null && spawnPoint != null && moneyData.Money >= moneyData.Bet)
        {
            moneyData.SubtractMoney();
            GameUI.instance.DisplayUI();

            GameObject spawnedBall = BallPool.Instance.GetBall();
            spawnedBall.transform.position = spawnPoint.position;
            spawnedBall.transform.SetParent(spawnPoint.transform, false);
        }
    }
}
