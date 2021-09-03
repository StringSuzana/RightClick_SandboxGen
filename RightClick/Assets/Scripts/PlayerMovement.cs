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
    private Vector3 Facing = Vector3.right;
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
        if (rb.position.x > agent.nextPosition.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Facing = Vector3.left;
        }
        else if (rb.position.x < agent.nextPosition.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Facing = Vector3.right;
        }
        //x=-1 left //x=1 right
    }
    private void FixedUpdate()
    {
        //if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        //{
        //    // limit movement speed diagonally, so you move at 70% speed
        //    movement.x *= moveLimiter;
        //    movement.y *= moveLimiter;
        //}
        //agent.Move(moveDir);
        //rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

}
