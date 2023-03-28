using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public LayerMask playerL, groundL;
    private Vector3 walkPoint;
    [Header("Enemy Settings")]
    public bool WalkPointSet;
    public bool PlayerInAttackRange;
    [Space]
    public float attackRange;
    public float walkPointRange;
    MoltenFreddy fred;
    public bool isFreddy;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerL = LayerMask.GetMask("Player");
        groundL = LayerMask.GetMask("Ground");


        if (isFreddy)
        {
           fred = GetComponent<MoltenFreddy>();
        }
    }
    void Update()
    {
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerL);
        if (!PlayerInAttackRange)
        {
            if(!isFreddy)
           Patrolling();
            if (isFreddy)
            {
                fred.DontAnim();
            }
        }
        else
        {
            ChasePlayer();
        }
    }



    private void Patrolling()
    {
     
        if (!WalkPointSet) SearchWalkPoint();
        if (WalkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
        }
    }
    private void ChasePlayer()
    {
        if (isFreddy)
        {
            fred.LetsAnim();
            agent.SetDestination(player.position);
            //transform.rotation = Quaternion.Euler(0,-270,0);
            //Debug.Log(transform.rotation);
        }
        else
        {
            agent.SetDestination(player.position);
            transform.rotation = Quaternion.Euler(0, -270, 0);
        }
        
    }
    private void SearchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up,5f, groundL))
        { 
            WalkPointSet = true;
            StartCoroutine(RestartWalkPoint());
        }
    }
    
    private IEnumerator RestartWalkPoint()
    {
        yield return new WaitForSeconds(20);
        WalkPointSet = false;
        yield return new WaitForSeconds(20);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(walkPoint, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
     
    }
}
