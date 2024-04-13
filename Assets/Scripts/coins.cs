using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    [SerializeField] private AudioSource coin;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Destroy(collision.gameObject);
            coin.Play();
        }
    }
}
