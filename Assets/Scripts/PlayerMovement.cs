using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed = 3;
    public float SideMovement = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * Movespeed * Time.deltaTime, Space.World);
        Debug.Log("Straight");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving left");
            transform.Translate(Vector3.left * SideMovement * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving right");
            transform.Translate(Vector3.right * SideMovement * Time.deltaTime);
        }
    }
}
