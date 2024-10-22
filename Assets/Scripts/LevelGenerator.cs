using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        Difficulty();
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
}
