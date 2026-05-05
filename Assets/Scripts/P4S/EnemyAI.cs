using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float updateRate = 0.3f; // как часто обновлять путь

    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateRate)
        {
            agent.SetDestination(player.position);
            timer = 0f;
        }
    }
}