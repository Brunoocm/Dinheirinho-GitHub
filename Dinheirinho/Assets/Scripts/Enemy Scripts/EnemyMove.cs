using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float stopDistance;

    public bool following = true;
    public bool knockback;

    Animator anim;
    Rigidbody2D rb;

    [HideInInspector] public GameObject player;
    Vector2 moveDir;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        agent.stoppingDistance = stopDistance;
        agent.angularSpeed = 0;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void FixedUpdate()
    {
        if (following && !knockback)
        {
            agent.isStopped = false;

            FollowPlayer();
        }
        else
        {
            agent.isStopped = true;
        }

    }

    void FollowPlayer()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > stopDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }
}
