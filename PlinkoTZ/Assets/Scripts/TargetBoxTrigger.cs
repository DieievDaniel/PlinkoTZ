using UnityEngine;
using System.Collections.Generic;

public class TargetBoxTrigger : MonoBehaviour
{
    private MoneyData moneyData;
    private List<RectTransform> spawnedObjects = new List<RectTransform>();
    private Transform spawnPoint;

    private void Start()
    {
        moneyData = FindObjectOfType<Canvas>().GetComponentInChildren<MoneyData>();

        GameObject spawnPosObject = GameObject.FindGameObjectWithTag("SpawnPos");
        if (spawnPosObject != null)
        {
            spawnPoint = spawnPosObject.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TargetBox"))
        {
            TargetMultiplier targetMultiplier = collision.gameObject.GetComponent<TargetMultiplier>();

            if (targetMultiplier != null && moneyData != null)
            {
                moneyData.AddMoney(targetMultiplier);
                GameUI.instance.DisplayUI();

                GameObject spawnedObject = Instantiate(collision.gameObject);
                RectTransform rectTransform = spawnedObject.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    rectTransform.position = spawnPoint.position;
                    rectTransform.SetParent(spawnPoint, false);

                    BoxCollider2D boxCollider = spawnedObject.GetComponent<BoxCollider2D>();
                    if (boxCollider != null)
                    {
                        boxCollider.enabled = false;
                    }

                    foreach (RectTransform obj in spawnedObjects)
                    {
                        obj.anchoredPosition += new Vector2(70, 0);
                    }

                    spawnedObjects.Add(rectTransform);
                }
            }

            BallPool.Instance.ReturnBall(gameObject);
        }
    }
}
