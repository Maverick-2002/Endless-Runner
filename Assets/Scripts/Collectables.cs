using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Collectables : MonoBehaviour
{
    public int rotationspeed = 1;
    void Update()
    {
        transform.Rotate(0, rotationspeed, 0, Space.World);
    }
   
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.Coin();
            AudioManager.Instance.PlaySFX(SoundEnum.Coin);
            Destroy(gameObject);
        }
    }

}
