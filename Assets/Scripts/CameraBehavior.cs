using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 3f, -4f);
   

    private Transform target;
    // Update is called once per frame
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target);


    }
}
