using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Speed")]
    public float baseSpeedMultiplier = 1f;
    public float currentSpeedMultiplier = 1f;

    float boostTimer = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        currentSpeedMultiplier = baseSpeedMultiplier;
    }

    void Update()
    {
        if (boostTimer > 0f)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
                currentSpeedMultiplier = baseSpeedMultiplier;
        }
    }

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        currentSpeedMultiplier = multiplier;
        boostTimer = duration;
    }
}
