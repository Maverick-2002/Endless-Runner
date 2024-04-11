using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed = 3;
    public float SideMovement = 5f;
    public float Lane = 1;
    public float DisLane = 2.5f;
    public int smoothness = 20;

    void Update()
    {
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
    }
}
