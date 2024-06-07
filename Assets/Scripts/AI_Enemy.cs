using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkPointRange;
    public float TimeBetweenAttackes;
    public float health;
    bool alreadyAttacked;
    //public GameObject projectile;
    public float sightRange, AttackRange;
    public bool PlayerIsInRange, PlayerInAttackRange;

    public void Awake()
    {

        Agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        // Check for player within range using layers
        bool playerInRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        bool playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!playerInRange)
        {
            Patroling();
        }
        else if (playerInRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        Agent.Move(Agent.destination);
    }

    private void Patroling()
    {
        if (!WalkPointSet) SearchWalkPoint();
        if (WalkPointSet) Agent.SetDestination(WalkPoint);

        Vector3 distanceToWalkPoint = transform.position - WalkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
            SearchWalkPoint(); // Find new walk point when reached
        }
    }

    private void SearchWalkPoint()
    {
        bool foundWalkPoint = false;

        // Implement your logic to generate a random walk point within WalkPointRange
        // considering the navigation mesh and avoiding obstacles.

        while (!foundWalkPoint) // Loop until a valid walk point is found
        {
            float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
            float randomX = Random.Range(-WalkPointRange, WalkPointRange);

            WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            // Check if the point is on the navigation mesh and not obstructed
            NavMeshHit hit;
            if (NavMesh.SamplePosition(WalkPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                foundWalkPoint = true;
                WalkPointSet = true;
            }
        }
    }

    public void ChasePlayer()
    {
        Agent.SetDestination(Player.position);
    }

    public void AttackPlayer()
    {
        Agent.SetDestination(transform.position); //
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestoryEnemy), 2f);
    }
    private void DestoryEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
