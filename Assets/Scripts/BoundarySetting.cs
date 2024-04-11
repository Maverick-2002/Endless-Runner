using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundarySetting : MonoBehaviour
{
    public static float Leftside = -3.25f;
    public static float Rightside = 3.25f;
    public float right;
    public float left;

    // Update is called once per frame
    void Update()
    {
        right = Rightside;
        left = Leftside;
        
    }
}
