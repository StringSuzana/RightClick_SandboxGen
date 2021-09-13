using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AstronautMovement : MonoBehaviour
{
    //[SerializeField]
    private new Camera camera;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;

    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var directionVector = (mousePosition - transform.position) * moveSpeed * Time.deltaTime;
        var quaternionRotation = Quaternion.LookRotation(Vector3.forward, directionVector);
        if (Input.GetButtonDown(InputKeys.Fire))
        {
            if (EventSystem.current.IsPointerOverGameObject() != true)
            {
                rb.AddForce(directionVector);
            }
           
        }
    }

    void FixedUpdate()
    {
        //if in space
        //rb.MovePosition(new Vector2(transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime, transform.position.y + vertical * moveSpeed * Time.fixedDeltaTime));
        //if on the earth
        // rb.AddForce(transform.right * horizontal * moveSpeed);
    }

}
public struct InputKeys
{
    public static string Fire = "Fire1";
    public static string HorizontalAxes = "Horizontal";
}
