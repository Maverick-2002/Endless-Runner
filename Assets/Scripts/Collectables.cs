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

}
