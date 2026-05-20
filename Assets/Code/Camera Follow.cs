using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 _currentVelocity;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CamPoint").transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _currentVelocity, smoothTime);
        }   
    }
}
