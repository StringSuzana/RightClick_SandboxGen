using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 3f;

    Vector2 movement;
    float moveLimiter = 0.7f;
    private Vector3 Facing = Vector3.right;
    private float jumpTimeRemaining;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(FadeIn());
    }
    void Update()
    {
        //User input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        Turn();

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Walk"))
        {
        }
    }
    private void Turn()
    {
        //x=-1 left //x=1 right
        if (movement == Vector2.right && Facing == Vector3.left)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Facing = Vector3.right;
        }
        else if (movement == Vector2.left && Facing == Vector3.right)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Facing = Vector3.left;
        }
    }
    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    IEnumerator FadeIn()
    {
        SpriteRenderer spriteRend = GetComponent<SpriteRenderer>();
        for (float f = 0f; f <= 1f; f += 0.1f)
        {
            Color c = spriteRend.material.color;
            c.a = f;
            spriteRend.material.color = c;
            yield return new WaitForSeconds(0.5f);
        }
        //corutine= function that can go to sleep and then resume 
    }
}
