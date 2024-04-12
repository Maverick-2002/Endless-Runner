using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy");
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
