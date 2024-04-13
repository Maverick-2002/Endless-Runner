using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed = 3;
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;
    public float jumpforce;
    public bool Jumping = false;
    public bool gravity = false;
    public Animator animator;
    public AudioSource Jump;

    void Update()
    {

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

        transform.Translate(Vector3.forward * Movespeed * Time.deltaTime, Space.World);
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
                transform.Translate(Vector3.up * Time.deltaTime * jumpforce, Space.World);

            }
            if (gravity == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpforce, Space.World);

            }

        }
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
