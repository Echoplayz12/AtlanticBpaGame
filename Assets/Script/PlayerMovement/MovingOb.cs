using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOb : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3;
    public Vector3 coord = new Vector3(4, 1, 1);

    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        transform.position = Vector3.SmoothDamp(transform.position, coord, ref ;
    }
}
