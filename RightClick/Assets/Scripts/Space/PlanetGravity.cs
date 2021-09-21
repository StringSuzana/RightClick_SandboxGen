using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    private float planetRadius;
    [SerializeField]
    private float gravityScale;
    [SerializeField]
    private float orbitDistance = 2.5f;
    private void Start()
    {
        var colliders = GetComponents<CircleCollider2D>();
        var planetCollider = colliders.FirstOrDefault(x => x.isTrigger != true);
        planetRadius = planetCollider.radius;
    }
    private void OnTriggerStay2D(Collider2D foreignBody)
    {
        var astronautMovement = foreignBody.gameObject.GetComponent(typeof(AstronautMovement)) as AstronautMovement;
        if (astronautMovement != null)
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
            Vector3 gravity = (transform.position - foreignBody.transform.position) * gravityScale;
            Vector3 gravityInfluence = gravity / Mathf.Pow(distFromCentreOfPlanet, 2);

            Debug.DrawLine(foreignBody.transform.position, gravity, Color.green, 0.3f); ;

            //Fake planets gravity
            foreignBody.gameObject.GetComponent<Rigidbody2D>().AddForce(gravityInfluence);
            //Rotate the little dude
            foreignBody.transform.up = Vector3.MoveTowards(foreignBody.transform.up, -gravity, gravityScale);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, orbitDistance);
    }
}


//public struct RevolutionPeriod
//{
//    public static Dictionary<string, float> PLANETS = new Dictionary<string, float> {
//        { "MERCURY", 88f } ,
//        { "VENUS", 225f } ,
//        { "EARTH", 365f } ,
//        { "MARS", 687f } ,
//        { "JUPITER", (365 * 12f) } ,
//        { "URANUS", (365 * 84f) } ,
//        { "NEPTUNE", (365 * 165f) }
//    };
//    public static float VENUS = 225f;
//    public static float EARTH = 365f;
//    public static float MARS = 687f;
//    public static float JUPITER = (365 * 12f);
//    public static float URANUS = (365 * 84f);
//    public static float NEPTUNE = (365 * 165f);

//    public float GetValueForPlanet(string planet)
//    {
//        return RevolutionPeriod.PLANETS[planet];
//    }
//}