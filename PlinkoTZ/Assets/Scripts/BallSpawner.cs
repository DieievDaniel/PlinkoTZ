using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private MoneyData moneyData;
    [SerializeField] private Button[] betButtons; 

    private int lastSpawnIndex = -1;
    private int activeBalls = 0; 

    public void SpawnBall()
    {
        if (BallPool.Instance != null && spawnPoints.Length > 0 && moneyData.Money >= moneyData.Bet)
        {
            int newSpawnIndex;
            do
            {
                newSpawnIndex = Random.Range(0, spawnPoints.Length);
            } while (newSpawnIndex == lastSpawnIndex);

            lastSpawnIndex = newSpawnIndex;
            Transform selectedSpawnPoint = spawnPoints[newSpawnIndex];

            moneyData.SubtractMoney();
            GameUI.instance.DisplayUI();

            GameObject spawnedBall = BallPool.Instance.GetBall();
            spawnedBall.transform.position = selectedSpawnPoint.position;
            spawnedBall.transform.SetParent(spawnPoints[0], false);

            activeBalls++;

            SetBetButtonsInteractable(false);
        }
    }

    public void BallReturnedToPool()
    {
        activeBalls--; 

        if (activeBalls <= 0)
        {
            SetBetButtonsInteractable(true);
        }
    }

    private void SetBetButtonsInteractable(bool state)
    {
        foreach (Button button in betButtons)
        {
            if (button != null)
            {
                button.interactable = state;
            }
        }
    }
}
