using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 15f;
    private float horizontal;
    private float vertical;

    public GameObject astrosaurus;
    private float shootingSpeed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            //fire out the astronaus
            Instantiate(astrosaurus, transform.position + (new Vector3(4f, 4f, 0f)), transform.rotation);
            astrosaurus.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, transform.position.y + 10f), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(new Vector2(transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime, transform.position.y));

    }
}
