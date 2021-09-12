using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //if in space
        //rb.MovePosition(new Vector2(transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime, transform.position.y + vertical * moveSpeed * Time.fixedDeltaTime));
        //if on the earth
       // rb.AddForce(transform.right * horizontal * moveSpeed);
    }

}

