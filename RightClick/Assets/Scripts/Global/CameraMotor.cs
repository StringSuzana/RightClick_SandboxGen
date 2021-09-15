using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lootAt;
    private float boundX = 1.5f;
    private float boundY = 1f;

    //LateUpdate is called AFTER Update and I want to move camera AFTER player moves. 
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //Check to see if the player is inside the bounds of the box focus on X axis
        float deltaX = lootAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lootAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        //Check to see if the player is inside the bounds of the box focus on Y axis
        float deltaY = lootAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lootAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
