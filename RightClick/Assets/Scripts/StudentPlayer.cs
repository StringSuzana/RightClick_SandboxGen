using UnityEngine;
using UnityEngine.AI;
public interface IPlayer
{
    void OpenDoors(IEnterable doorsToAnotherWorld);
}
public class StudentPlayer : MonoBehaviour, IPlayer
{
    Rigidbody2D rb;
    NavMeshAgent agent;

    private Animator animator;
    private string PlayerName = "Suzy";
    private Vector3 movement;
    private Vector3 Facing = Vector3.right;
    private new Camera camera;
    private bool isMoving = false;

    private void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    private void Update()
    {
        isMoving = agent.pathEndPosition.x != rb.position.x && agent.pathEndPosition.y != rb.position.y;
        if (Input.GetMouseButtonDown(0))
        {
            movement = camera.ScreenToWorldPoint(Input.mousePosition);
            //MOVE AGENT
            isMoving = agent.SetDestination(movement);
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            agent.SetDestination(movement);
            TurnPlayer(agent.path);
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void TurnPlayer(NavMeshPath path)
    {
        if (path.corners.Length >= 1)
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
    public void OpenDoors(IEnterable doorsToAnotherWorld)
    {
        Debug.Log("Player=> OpenDoors");
        //check some stuff
        doorsToAnotherWorld.Enter(this.PlayerName);
        //Player has encounter some enterable doors trigger
    }
}
