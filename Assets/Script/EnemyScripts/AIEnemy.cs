using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{

    //public Transform AIgoal;

    //private void Start()
    //{
    //    NavMeshAgent agent = GetComponent<NavMeshAgent>();  
    //    agent.destination = AIgoal.position;
    //}


    //some of the code is not working properly at the moment
    //this code might gonna be deleted and changed to something else

    
   //all the field
    [SerializeField]
    public NavMeshAgent navMeshAgent;
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 10;

    public float viewRadius = 15;
    public float viewAngle = 90;

    public LayerMask playerMask;
    public LayerMask obstacleMask;



    public float meshResolution = 1f; 
    public int edfeIterations = 4;
    public float edgeDistance = .5f;

    public Transform[] waypoints;
    int CurrenWayPointIndex;


    //as the name say, finds the last pos of the player
    Vector3 playerLastPosition = Vector3.zero;
    Vector3 PlayerPosition;

    float WaitTime;
    float TimeToRotate;
    bool PlayerInRange;
    bool PlayerClose;
    bool IsPotroling;
    bool caughtPlayer;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = Vector3.zero;
        IsPotroling = true;
        caughtPlayer = false;
        PlayerInRange = false;
        WaitTime = startWaitTime;
        TimeToRotate = timeToRotate;

        CurrenWayPointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[CurrenWayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        //as the frame updates the EnmeView is called to find player is its view range. 
        //at the moment not working
        EnemyView();

        if (!IsPotroling)
        {
            ChasingPlayer();
        }
        else
        {
            Patroling();
        }
    }

    //chasing player method, if the player 
    private void ChasingPlayer()
    {
        PlayerClose = false;
        playerLastPosition = Vector3.zero;

        if (!caughtPlayer)
        {
            MoveAI(speedRun);
            navMeshAgent.SetDestination(PlayerPosition);
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (WaitTime <= 0 && !caughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                IsPotroling = true;
                PlayerClose = false;
                MoveAI(speedWalk);
                TimeToRotate = timeToRotate;
                WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[CurrenWayPointIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    StopAI();
                    WaitTime -= Time.deltaTime;
                }
            }
        }
    }

    private void Patroling()
    {
        //while the player is not close or not in range of the view radius the enemy will patrol
        //CURRENTLY NOT WORKING 
        if (PlayerClose)
        {
            if (TimeToRotate <= 0)
            {
                MoveAI(speedWalk);
                SearchPlayer(playerLastPosition);
            }
            else
            {
                StopAI();
                TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            PlayerClose = false;
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[CurrenWayPointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (WaitTime < 0)
                {
                    NextPoint();
                    MoveAI(speedWalk);
                    WaitTime = startWaitTime;
                }
                else
                {
                    StopAI();
                    TimeToRotate -= Time.deltaTime;
                }
            }
        }
    }

    void MoveAI(float Speed)
    {
        navMeshAgent.isStopped = false;

        navMeshAgent.speed = Speed;
    }
    void StopAI()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    public void NextPoint()
    {
        CurrenWayPointIndex = (CurrenWayPointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[CurrenWayPointIndex].position);
    }

    void SearchPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= +0.3)
        {
            if (WaitTime <= 0)
            {
                PlayerClose = false;
                MoveAI(speedWalk);
                navMeshAgent.SetDestination(waypoints[CurrenWayPointIndex].position);
                WaitTime = startWaitTime;
                TimeToRotate = timeToRotate;
            }
            else
            {
                StopAI();
                WaitTime -= Time.deltaTime;
            }
        }
    }

    void EnemyView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);

                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    PlayerInRange = true;
                    IsPotroling = false;
                }
                else
                {
                    PlayerInRange = false;
                    IsPotroling = true;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                PlayerInRange = false;
            }
            if (PlayerInRange)
            {
                PlayerPosition = player.transform.position;
            }
        }
    }
}
