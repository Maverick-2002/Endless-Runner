using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Destroy");
        }

    }
}