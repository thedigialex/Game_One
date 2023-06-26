using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 2f;
    public float detectionRadius = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null || Vector3.Distance(transform.position, player.position) > detectionRadius)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 movement = direction * movementSpeed;

        rb.velocity = movement;
    }
}
