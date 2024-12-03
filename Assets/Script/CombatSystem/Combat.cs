using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.2f;
    //public LayerMask enemyLayers;

   // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
       // Physics.OverlapBox(attackPoint.position, attackRange, enemyLayers);
    }
}
