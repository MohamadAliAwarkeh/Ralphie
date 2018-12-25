using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    //Public Variables
    [Header("Ralphie Variables")]
    public float speed;
    public float stoppingDistance;

    [Header("House Destruction")]
    public float destructionRadius;
    public float explosionForce;

    //Private Variables
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        HouseDestruction();
    }

    public void ComeToPlayer()
    {
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void HouseDestruction()
    {
        //Initially we will make an array which searches through each object that is colliding with the player
        //within the specified bounderies, and then we will call another script in which we destroy the
        //original object and instantiate a broken version, then we search for colliders again, but this
        //time for the new destroyed buildings, and add force to them
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, destructionRadius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destructable dest = nearbyObject.GetComponent<Destructable>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, destructionRadius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, destructionRadius);
            }
        }
    }
}
