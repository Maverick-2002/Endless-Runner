using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private AudioSource fuel;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            AudioManager.Instance.PlaySFX(SoundEnum.Fuel);
            Destroy(collision.gameObject);
        }
    }
}
