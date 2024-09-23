using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Health = 100;
    [SerializeField] UnityEngine.Object Object;
    // Update is called once per frame

    public void Update()
    {


    }
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Destroy(Object);
        }
    }
    



}
