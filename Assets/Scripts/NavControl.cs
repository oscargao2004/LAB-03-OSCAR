using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    [SerializeField] private float animSpeed;
    [SerializeField] private float walkSpeed;
    public GameObject target;
    public GameObject lookTarget;
    private NavMeshAgent agent;
    private Animator animator;

    private bool isWalking = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookTarget.transform.position);
        agent.speed = walkSpeed;
        animSpeed = walkSpeed * 0.9f;
        animator.speed = animSpeed;
        if (isWalking)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Purple")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Purple")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
