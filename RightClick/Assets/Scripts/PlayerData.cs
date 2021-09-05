using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    //public Text pointsText;
    public float extraPoints;

    public void SetExtraPoints(float points)
    {
        Debug.Log("SetExtraPoints: " + points);

        extraPoints = points;
    }
    public void AddExtraPoints(float points)
    {
        Debug.Log("AddExtraPoints: " + points);
        extraPoints += points;
    }
}
