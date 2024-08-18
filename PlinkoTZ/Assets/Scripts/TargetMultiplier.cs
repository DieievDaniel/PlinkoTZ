using UnityEngine;

public class TargetMultiplier : MonoBehaviour
{

    [SerializeField] private float multiplier;

    public float GetMultiplier()
    {
        return multiplier;
    }

    public void SetMultiplier(float value)
    {
        multiplier = value;
    }
}
