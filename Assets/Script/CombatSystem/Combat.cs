using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Combat : MonoBehaviour
{
    PlayerStats myStats;
    private void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }
    //public void Attack (PlayerStats targetStats)
    //{
    //    targetStats.TakeDamage(myStats.damage);

    //}

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
