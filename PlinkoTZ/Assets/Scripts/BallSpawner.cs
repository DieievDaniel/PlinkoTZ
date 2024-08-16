using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    public void SpawnBall()
    {
        if (ballPrefab != null && spawnPoint != null)
        {
            GameObject spawnedBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            spawnedBall.transform.SetParent(spawnPoint.transform, false);
        }
    }
}
