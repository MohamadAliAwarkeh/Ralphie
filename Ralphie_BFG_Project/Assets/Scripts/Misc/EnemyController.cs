using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Public Variables
    [Header("Enemy Variables")]
    public float lookRadius;
    public FollowPlayer ralphie;

    //Private Variables
    NavMeshAgent agent;
    Transform player;

    void Start()
    {
        //Setting the navMeshAgent
        agent = GetComponent<NavMeshAgent>();

        //Setting the player
        player = PlayerFinder.instance.player.transform;
    }

    void Update()
    {
        //Getting the distance from the player to the enemy
        float distance = Vector3.Distance(player.position, transform.position);
        /*
        //then checking if the distance is within the lookRadius
        if (distance <= lookRadius)
        {
            //Chase player
            agent.SetDestination(player.position);

            //First we check if the distance is within the stopping distance
            if (distance <= agent.stoppingDistance)
            {
                //attack the player

                //face the player
                FaceTarget();
            }
        }
        */

        if (ralphie.housesDestroyed >= 1)
        {
            //Chase player
            agent.SetDestination(player.position);

            //First we check if the distance is within the stopping distance
            if (distance <= agent.stoppingDistance)
            {
                //attack the player

                //face the player
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        //Get a rotation to the player we want to face
        Vector3 direction = (player.position - transform.position).normalized;

        //Point towards the said player
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        //update our rotation to face that direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
