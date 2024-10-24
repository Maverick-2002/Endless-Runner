using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public static float MoveSpeed = -8f;
    

    void Update()
    {
        if (LevelGenerator.isMovement == true)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
        }
    }
}
