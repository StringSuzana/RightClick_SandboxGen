using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var astronaut = collision.gameObject.GetComponent(typeof(AstronautMovement)) as AstronautMovement;
        if (astronaut != null)
        {
            Time.timeScale = 0;
            StartCoroutine(astronaut.FadeAway());
        }

    }
}
