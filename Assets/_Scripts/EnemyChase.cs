using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3.5f;
    public float stopDistance = 2f;
    public Light flashlight; // Reference to the player's flashlight
    public float repelDistance = 7f;

    private NavMeshAgent agent;
    private bool isRepelled = false;
    private bool playerCaught = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (flashlight == null)
        {
            flashlight = GameObject.FindGameObjectWithTag("FlashLight").GetComponent<Light>();
        }
    }

    void Update()
    {
        if (!agent.isOnNavMesh || playerCaught) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if in flashlight range
        if (flashlight != null && flashlight.enabled && IsInFlashlightCone())
        {
            isRepelled = true;
            agent.isStopped = true;
            return;
        }
        else
        {
            isRepelled = false;
            agent.isStopped = false;
        }

        // Chase player
        if (!isRepelled && distanceToPlayer > stopDistance)
        {
            agent.SetDestination(player.position);
        }

        // Check for losing condition
        if (distanceToPlayer <= stopDistance)
        {
            playerCaught = true;
            Debug.Log("You got caught!");
            // TODO: Trigger game over
        }
    }

    bool IsInFlashlightCone()
    {
        Vector3 toEnemy = transform.position - flashlight.transform.position;
        float angle = Vector3.Angle(flashlight.transform.forward, toEnemy);

        return angle < flashlight.spotAngle / 2 && toEnemy.magnitude < repelDistance;
    }
}
