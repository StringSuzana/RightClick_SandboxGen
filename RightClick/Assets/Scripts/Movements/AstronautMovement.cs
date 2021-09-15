using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AstronautMovement : MonoBehaviour
{
    private new Camera camera;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Material dissolve;

    private bool canMove;
    private Vector3 directionVector = Vector3.zero;
    private static float currentDissolve;
    

    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        currentDissolve = 1f;
        dissolve.SetFloat("_Fade", currentDissolve);
    }

    void Update()
    {

        //var quaternionRotation = Quaternion.LookRotation(Vector3.forward, directionVector);
        if (Input.GetButtonDown(InputKeys.Fire))
        {
            if (EventSystem.current.IsPointerOverGameObject() != true)
            {
                Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
                directionVector = (mousePosition - transform.position) * moveSpeed * Time.deltaTime;
                rb.AddForce(directionVector);
            }

        }
        print(directionVector);
    }

    //void FixedUpdate()
    //{
    //    if (canMove == true)
    //    {
            
    //        directionVector = Vector3.zero;
    //    }
    //    //if in space
    //    //rb.MovePosition(new Vector2(transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime, transform.position.y + vertical * moveSpeed * Time.fixedDeltaTime));
    //    //if on the earth
    //    // rb.AddForce(transform.right * horizontal * moveSpeed);
    //}

    public IEnumerator FadeAway()
    {
        print("currentDissolve" + currentDissolve);
        print("fade: " + dissolve.GetFloat("_Fade"));
        var delay = 0.2f;
        
        while (dissolve.GetFloat("_Fade") > 0f)
        { 
            dissolve.SetFloat("_Fade", currentDissolve);
            yield return new WaitForSecondsRealtime(delay);
            currentDissolve -= 0.1f;
        }
    }
}
public struct InputKeys
{
    public static string Fire = "Fire1";
    public static string HorizontalAxes = "Horizontal";
}
