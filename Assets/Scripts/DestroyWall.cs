using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroy");
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(other.gameObject);
        }

    }
}