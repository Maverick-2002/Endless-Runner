using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;
    public Animator animator;
    private float distanceCovered = 0f;
    public float score;

    // New variables for rotation
    private float targetTiltZ = 0f;
    private float tiltAngle = 15f; // The angle to tilt when changing lanes
    private float rotationSpeed = 5f; // Speed of tilt transition
    private bool isChangingLane = false;
    private float laneChangeDelay = 0.15f; // Delay before lane change

    void Update()
    {
        distanceCovered += Time.deltaTime * -PlatformMovement.MoveSpeed;

        // Check for lane change input
        if (!isChangingLane)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Lane > 0)
                {
                    StartCoroutine(ChangeLane(-1));
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Lane < 2)
                {
                    StartCoroutine(ChangeLane(1));
                }
            }
        }

        // Calculate target position based on the current lane
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * Vector3.up;
        if (Lane == 0)
        {
            targetPosition += Vector3.left * DisLane;
        }
        else if (Lane == 2)
        {
            targetPosition += Vector3.right * DisLane;
        }

        // Smoothly move to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

        // Smoothly interpolate rotation to target tilt angle
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -targetTiltZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    IEnumerator ChangeLane(int direction)
    {
        isChangingLane = true;
        targetTiltZ = direction * tiltAngle;
        // Wait for the delay before changing lanes
        yield return new WaitForSeconds(laneChangeDelay);
       
        Lane += direction;
        targetTiltZ = 0f; // Reset tilt after switching
        isChangingLane = false;
    }

    public int CalculateScore()
    {
        score = distanceCovered * 2.5f;
        return (int)(score);
    }
}
