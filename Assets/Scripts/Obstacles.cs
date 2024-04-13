using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Model;
    public GameObject LevelGenerate;
    [SerializeField] private AudioSource coin;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")){
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            Model.GetComponent<Animator>().SetTrigger("Death");
            LevelGenerate.GetComponent<LevelGenerator>().enabled = false;

        }

    }
}
