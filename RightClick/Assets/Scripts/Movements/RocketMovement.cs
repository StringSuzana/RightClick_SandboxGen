using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.AddForce(transform.right * horizontal * moveSpeed);
    }
}
