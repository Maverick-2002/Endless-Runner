using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;
    private float distanceCovered = 0f;
    public float score;
    private float targetTiltZ = 0f;
    private float tiltAngle = 15f;
    private float rotationSpeed = 5f;
    private bool isChangingLane = false;
    private float laneChangeDelay = 0.15f;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public ParticleSystem leftparticleFront;
    public ParticleSystem rightparticleFront;
    public ParticleSystem leftparticleBack;
    public ParticleSystem rightparticleBack;

    void Start()
    {
        InvokeRepeating(nameof(ConsumeFuelOverTime),1f,1f);
    }

    void Update()
    {
        distanceCovered += Time.deltaTime * -PlatformMovement.MoveSpeed;

        if (!isChangingLane)
        {
            HandleInput();
        }

        Vector3 targetPosition = transform.position;
        if (Lane == 0)
        {
            targetPosition.x = -DisLane;
        }
        else if (Lane == 1)
        {
            targetPosition.x = 0;
        }
        else if (Lane == 2)
        {
            targetPosition.x = DisLane;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -targetTiltZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Lane > 0)
            {
                rightparticleFront.Stop();
                rightparticleBack.Stop();
                leftparticleFront.Play();
                leftparticleBack.Play();
                StartCoroutine(ChangeLane(-1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Lane < 2)
            {
                leftparticleFront.Stop();
                leftparticleBack.Stop();
                rightparticleFront.Play();
                rightparticleBack.Play();
                StartCoroutine(ChangeLane(1));
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReactToUnity.instance.GiveEnergy_Unity(50);
            LevelGenerator.Instance.StartMovement();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(swipeDelta.x) > 100)
        {
            if (swipeDelta.x > 0)
            {
                if (Lane < 2)
                {
                    StartCoroutine(ChangeLane(1));
                }
            }
            else
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
        targetTiltZ = direction * tiltAngle;
        yield return new WaitForSeconds(laneChangeDelay);
        Lane += direction;
        targetTiltZ = 0f;
        //leftparticle.SetActive(false);
        //rightparticle.SetActive(false);
        isChangingLane = false;
    }

    public int CalculateScore()
    {
        score = distanceCovered * 2.5f;
        return (int)(score);
    }

    public void ConsumeFuelOverTime()
    {
        UIManager.Instance.FuelDecrease(5); 
    }
}
