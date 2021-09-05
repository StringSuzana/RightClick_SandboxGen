using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public interface IPlayer
{
  void OpenDoors(IEnterable doorsToAnotherWorld);
}
public class PlayerMovement : MonoBehaviour, IPlayer
{
    private string PlayerName = "Suzy";
    private Animator animator;
    Rigidbody2D rb;
    NavMeshAgent agent;
    [SerializeField]
    private float speed = 20f;
    Vector3 movement;
    private new Camera camera;

    bool isMoving;
    private void Start()
    {
        camera = Camera.main;
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
            movement = camera.ScreenToWorldPoint(Input.mousePosition);
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

    public void OpenDoors(IEnterable doorsToAnotherWorld)
    {
        Debug.Log("Player=> OpenDoors");
        //check some stuff
        doorsToAnotherWorld.Enter(this.PlayerName);
        //Player has encounter some enterable doors trigger
    }
}
