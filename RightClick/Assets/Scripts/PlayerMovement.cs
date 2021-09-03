using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    Rigidbody2D rb;
    NavMeshAgent agent;
    [SerializeField]
    private float speed = 20f;
    Vector3 movement;
    public Camera cam;

    bool isMoving;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            movement = cam.ScreenToWorldPoint(Input.mousePosition);
            //MOVE AGENT

            isMoving = agent.SetDestination(movement);
            if (isMoving)
            {
                agent.SetDestination(movement);
             
            }
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        Turn();


    }
    private void Turn()
    {
        //x=-1 left //x=1 right
        if (rb.position.x > agent.nextPosition.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.position.x < agent.nextPosition.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
