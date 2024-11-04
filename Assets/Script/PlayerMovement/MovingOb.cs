using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOb : MonoBehaviour
{
    public float speed = 3;
    public float smoothTime = 0.5f;
    public Vector3 coord = new Vector3(1, 1, 4);
    Vector3 currentVelocity;

    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        //transform.position = Vector3.SmoothDamp(transform.position, coord, ref currentVelocity, smoothTime;
    }
}
