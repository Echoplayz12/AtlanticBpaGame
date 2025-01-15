using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIControlV2 : PlayerStats
{
    public float viewRadius;
    public float atkRadius;
    //public float damage;
    //public float atkTimer;
    public bool inRange;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManagaer.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < viewRadius) 
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack the target
                // face the target
                FaceTarget();
            }
        }
        //learned that with out a set timer for enemy attacking the player health would drop to 0 in an instance lol
        //also not gonna do health system
        if (distance <= atkRadius && !inRange)
        {
            inRange = true;
            SceneManager.LoadScene(4);
        }
    }
    //private void FixedUpdate()
    //{
    //    InRange();
    //}
    //public override void TakeDamage(float Damage)
    //{
    //    Damage = damage;
    //    base.TakeDamage(Damage);
    //}
    //void InRange()
    //{
    //    float distance = Vector3.Distance(transform.position, target.position);
    //    if (distance <= atkRadius)
    //    {
    //        inRange = true;

    //        //atkTimer -= Time.deltaTime;
    //        //if (atkTimer < 0)
    //        //{
    //        //    inRange = true;
    //        //}
    //        //else
    //        //{
    //        //    inRange = false;
    //        //}
    //    }
    //    else
    //    {
    //        inRange = false;
    //    }
    //}
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 8f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, atkRadius);
    }
}
