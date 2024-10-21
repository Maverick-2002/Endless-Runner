using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Lane = 1; // Current lane (0: left, 1: center, 2: right)
    public float DisLane = 2.5f; // Distance between lanes
    public int smoothness = 20; // Smoothness factor for position transition
    public Animator animator; // Animator for player animations
    private float distanceCovered = 0f; // Distance covered for scoring
    public float score; // Player score

    // New variables for rotation
    private float targetTiltZ = 0f; // Target tilt angle for lane changes
    private float tiltAngle = 15f; // Angle to tilt when changing lanes
    private float rotationSpeed = 5f; // Speed of tilt transition
    private bool isChangingLane = false; // Flag for lane change state
    private float laneChangeDelay = 0.15f; // Delay before lane change

    private Vector2 startTouchPosition; // Starting position of the touch
    private Vector2 endTouchPosition; // Ending position of the touch

    void Update()
    {
        // Update distance covered based on speed
        distanceCovered += Time.deltaTime * -PlatformMovement.MoveSpeed;

        // Check for lane change input
        if (!isChangingLane)
        {
            HandleInput();
        }

        // Calculate target position based on the current lane
        Vector3 targetPosition = transform.position;
        if (Lane == 0) // Left lane
        {
            targetPosition.x = -DisLane;
        }
        else if (Lane == 1) // Center lane
        {
            targetPosition.x = 0;
        }
        else if (Lane == 2) // Right lane
        {
            targetPosition.x = DisLane;
        }

        // Smoothly move to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

        // Smoothly interpolate rotation to target tilt angle
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -targetTiltZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        // Keyboard input for lane changing
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

        // Touch input for mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position; // Record the start position of the touch
                    break;
                case TouchPhase.Ended:
                    endTouchPosition = touch.position; // Record the end position of the touch
                    DetectSwipe(); // Detect swipe direction
                    break;
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition; // Calculate the swipe distance

        // Check if the swipe is significant enough to consider it a valid swipe
        if (Mathf.Abs(swipeDelta.x) > 100) // Change this value to adjust swipe sensitivity
        {
            if (swipeDelta.x > 0) // Swipe right
            {
                if (Lane < 2)
                {
                    StartCoroutine(ChangeLane(1));
                }
            }
            else // Swipe left
            {
                if (Lane > 0)
                {
                    StartCoroutine(ChangeLane(-1));
                }
            }
        }
    }

    IEnumerator ChangeLane(int direction)
    {
        isChangingLane = true;
        targetTiltZ = direction * tiltAngle; // Set target tilt angle
        yield return new WaitForSeconds(laneChangeDelay); // Wait before changing lanes

        Lane += direction; // Change the lane
        targetTiltZ = 0f; // Reset tilt after switching
        isChangingLane = false;
    }

    public int CalculateScore()
    {
        score = distanceCovered * 2.5f;
        return (int)(score);
    }
}
