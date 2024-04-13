using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 8;
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;
    public float jumpForce=4;
    public bool Jumping = false;
    public bool gravity = false;
    public Animator animator;
    public AudioSource Jump;
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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Jumping == false)
            {
                Jumping = true;
                Jump.Play();
                animator.SetBool("Jumping", true);
                StartCoroutine(JumpSequence());
            }
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

        if (Jumping == true)
        {
            if (gravity == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpForce, Space.World);
            }
            if (gravity == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpForce, Space.World);
            }
        }
    }

    public int CalculateScore()
    {
        score = distanceCovered * 2;
        return (int)(score);
    }

    IEnumerator JumpSequence()
    {
        float initialHeight = transform.position.y;
        yield return new WaitForSeconds(0.45f);
        gravity = true;
        yield return new WaitForSeconds(0.45f);
        Jumping = false;
        gravity = false;
        animator.SetBool("Jumping", false);
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
    }
}
