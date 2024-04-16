using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Newpos = new Vector3(offset.x + target.position.x, transform.position.y , offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position,Newpos, 10*Time.deltaTime);
    }
}
