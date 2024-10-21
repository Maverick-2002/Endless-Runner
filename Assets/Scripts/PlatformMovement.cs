using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public static float MoveSpeed = -8f;
    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 30)
        {
            timeElapsed = 0f;
            MoveSpeed *= 1.2f;
            UIManager.Instance.DifficultyUI();
            print("Dif increased");


        }
        // Move the platform forward continuously
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
    }
}
