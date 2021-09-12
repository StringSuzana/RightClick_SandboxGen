using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField]
    private float gravityScale, planetRadius;
    private float orbitDistance = 2.5f;
    private void OnTriggerStay2D(Collider2D foreignBody)
    {
        float distFromCentreOfPlanet = (Vector3.Distance(foreignBody.transform.position, transform.position));
        if ((distFromCentreOfPlanet - planetRadius) < orbitDistance)
        {
            foreignBody.attachedRigidbody.drag = 10f * (1/distFromCentreOfPlanet) * Time.deltaTime;
        }
        else
        {
            foreignBody.attachedRigidbody.drag = 0.0f;

        }
        print("drag: "+foreignBody.attachedRigidbody.drag);
        Vector3 dir0 = (transform.position - foreignBody.transform.position) * gravityScale;
        Vector3 dir = dir0 / (distFromCentreOfPlanet * distFromCentreOfPlanet);

       
        Debug.DrawLine(foreignBody.transform.position, dir0, Color.green, 0.3f); ;

        foreignBody.gameObject.GetComponent<Rigidbody2D>().AddForce(dir);
        foreignBody.transform.up = Vector3.MoveTowards(foreignBody.transform.up, -dir, gravityScale);
    }

}
