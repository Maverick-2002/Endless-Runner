using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   // [SerializeField] private AudioSource coins;
    public int rotationspeed = 1;
    void Start()
    {
       // coins = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(0, rotationspeed, 0, Space.World);
    }
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //AudioManager.instance.PlayAudio(coins);
            gameObject.SetActive(false);
        }

    }*/

}
