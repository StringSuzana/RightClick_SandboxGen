using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraPointsBar : MonoBehaviour
{
    private Slider imageExtraPoints;

    [Tooltip("Current number of points.")]
    private float extraPoints;
    [Tooltip("Total number of points that fit into points bar. Might be max points before alerting teacher with scores.")]
    private float fullPoints = 50f;

    void Start()
    {
        imageExtraPoints = GameObject.FindGameObjectWithTag("ExtraPointsBar").GetComponent<Slider>();
        //TODO:
        //Check to see if data is loaded.
        Display();
    }

    private void Display()
    {
        imageExtraPoints.value = PlayerData.sharedInstance.StudentInfo.totalExtraPoints;
    }

    public void CompletedQuest(float numberOfPoints)
    {
        PlayerData.sharedInstance.AddExtraPoints(numberOfPoints);
        extraPoints += numberOfPoints;
        if (numberOfPoints >= fullPoints)
        {
            //TODO
            //display something shiny
            //notify teacher ?
        }
    }
}
