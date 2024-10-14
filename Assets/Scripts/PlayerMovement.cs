using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 8;
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;
    public Animator animator;
    private float distanceCovered = 0f;
    public float score;
    private float timeElapsed;

    void Update()
    {
        distanceCovered += Time.deltaTime * MoveSpeed;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 30)
        {
            MoveSpeed *= 1.2f;
            timeElapsed = 0f;
            UIManager.Instance.DifficultyUI();
        }

        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Lane--;
            if (Lane == -1)
            {
                Lane = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Lane++;
            if (Lane == 3)
            {
                Lane = 2;
            }
        }
        Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (Lane == 0)
        {
            targetposition += Vector3.left * DisLane;
        }
        else if (Lane == 2)
        {
            targetposition += Vector3.right * DisLane;
        }
        transform.position = Vector3.Lerp(transform.position, targetposition, smoothness * Time.deltaTime);
    }

    public int CalculateScore()
    {
        score = distanceCovered * 2.5f;
        return (int)(score);
    }
}
