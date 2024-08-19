using UnityEngine;
using System.Collections.Generic;

public class TargetBoxTrigger : MonoBehaviour
{
    private MoneyData moneyData;
    private List<RectTransform> spawnedObjects = new List<RectTransform>();
    private Transform spawnPoint;
    private bool hasTouchedTargetBox = false;
    private BallSpawner ballSpawner;

    private void Start()
    {
        moneyData = FindObjectOfType<Canvas>().GetComponentInChildren<MoneyData>();

        GameObject spawnPosObject = GameObject.FindGameObjectWithTag("SpawnPos");
        if (spawnPosObject != null)
        {
            spawnPoint = spawnPosObject.transform;
        }

        ballSpawner = FindObjectOfType<BallSpawner>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTouchedTargetBox) return;

        if (collision.gameObject.CompareTag("TargetBox"))
        {
            TargetMultiplier targetMultiplier = collision.gameObject.GetComponent<TargetMultiplier>();

            if (targetMultiplier != null && moneyData != null)
            {
                moneyData.AddMoney(targetMultiplier);
                GameUI.instance.DisplayUI();

                GameObject spawnedObject = Instantiate(collision.gameObject);
                RectTransform rectTransform = spawnedObject.GetComponent<RectTransform>();

                rectTransform.position = spawnPoint.position;
                rectTransform.SetParent(spawnPoint, false);

                BoxCollider2D boxCollider = spawnedObject.GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }

                spawnedObjects.Add(rectTransform);

                hasTouchedTargetBox = true;

                BallPool.Instance.ReturnBall(gameObject);

                if (ballSpawner != null)
                {
                    ballSpawner.BallReturnedToPool();
                }
            }
        }
    }
}
