using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool Instance { get; private set; }

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> ballPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ballPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            ballPool.Enqueue(ball);
        }
    }

    public GameObject GetBall()
    {
        if (ballPool.Count > 0)
        {
            GameObject ball = ballPool.Dequeue();
            ball.SetActive(true);
            return ball;
        }
        else
        {
            GameObject ball = Instantiate(ballPrefab);
            return ball;
        }
    }

    public void ReturnBall(GameObject ball)
    {
        ball.SetActive(false);
        ballPool.Enqueue(ball);
    }
}
