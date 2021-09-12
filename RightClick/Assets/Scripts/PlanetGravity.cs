using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField]
    private float gravityScale, planetRadius;
    [SerializeField]
    private float orbitDistance = 2.5f;
    private void OnTriggerStay2D(Collider2D foreignBody)
    {
        float distFromCentreOfPlanet = (Vector3.Distance(foreignBody.transform.position, transform.position));
        if ((distFromCentreOfPlanet - planetRadius) < orbitDistance)
        {
            foreignBody.attachedRigidbody.drag = 10f * (1 / distFromCentreOfPlanet) * Time.deltaTime;
        }
        else
        {
            foreignBody.attachedRigidbody.drag = 0.0f;

        }
        print("drag: " + foreignBody.attachedRigidbody.drag);
        Vector3 gravity = (transform.position - foreignBody.transform.position) * gravityScale;
        Vector3 gravityInfluence = gravity / Mathf.Pow(distFromCentreOfPlanet, 2);

        if (transform.name == "MARS")
        {
            Debug.DrawLine(foreignBody.transform.position, gravity, Color.red, 0.3f); ;

        }
        else
        {
            Debug.DrawLine(foreignBody.transform.position, gravity, Color.green, 0.3f); ;

        }

        //Fake planets gravity
        foreignBody.gameObject.GetComponent<Rigidbody2D>().AddForce(gravityInfluence);
        //Rotate the little dude
        foreignBody.transform.up = Vector3.MoveTowards(foreignBody.transform.up, -gravity, gravityScale);
    }

}
