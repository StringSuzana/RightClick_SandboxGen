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

        if (Input.GetButtonDown("Jump"))
        {
            //fire out the astronaus
            
            var newAstro = Instantiate(astrosaurus, transform.position, transform.rotation);
            newAstro.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        //rb.MovePosition(new Vector2(transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime, transform.position.y));
        if (horizontal != 0)
        {
            rb.velocity = (new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime, 0f));
        }
    }
}
