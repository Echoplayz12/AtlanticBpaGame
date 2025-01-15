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
    public float damage;
    private float AtkTime;
    public float atkTimer;
    public float damageTimer;
    //public bool inRange;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManagaer.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        AtkTime = atkTimer;
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
    }
    private void FixedUpdate()
    {
        InRange();
    }
    public override void TakeDamage(float Damage)
    {
        Damage = damage;
        base.TakeDamage(Damage);
    }
    void InRange()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= atkRadius)
        {
            atkTimer -= Time.deltaTime;
            if (atkTimer <= 0)
            {  
                if(damageTimer <= 0)
                {
                    TakeDamage(weapon.getValue());
                    Debug.Log(transform.name + "Player current HP is at " + currentHealth);

                }
                if (currentHealth <= 0)
                {
                    SceneManager.LoadScene(2);
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
            }
        }
    }
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
