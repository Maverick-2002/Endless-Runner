using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private float timeElapsed;
    public static bool isMovement = true;
    public static LevelGenerator Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isMovement)
        {
            Difficulty();
        }
    }

    void Difficulty()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 30)
        {
            timeElapsed = 0f;
            PlatformMovement.MoveSpeed *= 1.2f;
            UIManager.Instance.DifficultyUI();
            print(PlatformMovement.MoveSpeed);
        }
    }
    // Method to start platform movement
    public void StartMovement()
    {
        isMovement = true;
    }

    // Method to stop platform movement
    public void StopMovement()
    {
        isMovement = false;
    }
}
