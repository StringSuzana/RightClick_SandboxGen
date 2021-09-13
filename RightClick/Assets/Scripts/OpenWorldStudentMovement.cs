using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class OpenWorldStudentMovement : MonoBehaviour
{
    Rigidbody2D rb;
    NavMeshAgent agent;

    private Animator animator;
    private Vector3 movement;
    private Vector3 Facing = Vector3.right;
    private new Camera camera;
    private bool isMoving = false;
    private float giveUpPathTime = 3f;
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = agent.hasPath;
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() != true)
            {
                movement = camera.ScreenToWorldPoint(Input.mousePosition);
                isMoving = agent.SetDestination(movement);
            }

        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            agent.SetDestination(movement);//MOVE AGENT
            TurnPlayer(agent.path);
        }
        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);
    }
    void TurnPlayer(NavMeshPath path)
    {
        if (path.corners.Length > 1)
        {
            Vector3 nextCorner = path.corners[1];
            if (rb.transform.position.x > nextCorner.x && Facing == Vector3.right)
            {
                Debug.Log("GO LEFT");
                transform.localScale = new Vector3(-1f, 1f, 1f);
                Facing = Vector3.left;
            }
            else if (rb.position.x < nextCorner.x && Facing == Vector3.left)
            {
                Debug.Log("GO right");
                transform.localScale = new Vector3(1f, 1f, 1f);
                Facing = Vector3.right;
            }
        }
    }
}
