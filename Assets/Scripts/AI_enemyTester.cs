using UnityEngine;
using UnityEngine.AI;

public class AI_enemyTester : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player; // Assign the player transform in the Inspector
    public float sightRange = 2f;
    private float updatePathTimer = 0f;
    public float updatePathInterval = 0.2f; // How often to update the path (seconds)

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
   
    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("No player assigned! Please assign the player transform in the Inspector.");
            return;
        }

        updatePathTimer += Time.deltaTime;

        if (updatePathTimer >= updatePathInterval)
        {
             FollowThePlayerInSight();
            updatePathTimer = 0f;
        }
    }

    private void FollowThePlayerInSight()
    {
        bool isPlayerInRange = isPlayerInSightRange();
        if(isPlayerInRange)
        {
            agent.SetDestination(player.position);
        }else{
            agent.SetDestination(player.position);
            agent.isStopped = false;
        }
    }
    private bool isPlayerInSightRange()
    {
            return Vector3.Distance(transform.position, player.position) <= sightRange;
    }
}


