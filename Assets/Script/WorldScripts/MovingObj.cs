using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    public Transform[] wayPoint;
    public int targetPoint;
    public float speed;

    // Update is called once per frame
    void Start()
    {
        targetPoint = 0;
    }
    void Update()
    {   
        for (int i = 0; i < 1;)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[0].position, speed * Time.deltaTime);
        }
    }
}
