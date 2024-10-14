using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{

    public float speed = 2;
    public Vector3 pos = new Vector3 (0, 1, 4);

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards (transform.position, pos, speed * Time.deltaTime);
    }
}
