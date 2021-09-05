using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraPointsBar : MonoBehaviour
{
    private Slider imageExtraPoints;
    private float extraPoints = 5f;//TODO: start at zero
    private float fullPoints = 50f;
    void Start()
    {
        imageExtraPoints = GameObject.FindGameObjectWithTag("ExtraPointsBar").GetComponent<Slider>();
        //Load data from somewhere
        Display();
    }

    private void Display()
    {
        PlayerData.sharedInstance.SetExtraPoints(extraPoints); //do this after finishing quiz !
        imageExtraPoints.value = PlayerData.sharedInstance.extraPoints;
    }

    public void CompletedQuest(float numberOfPoints)
    {
        //increase extraPoints
        PlayerData.sharedInstance.AddExtraPoints(numberOfPoints);
        extraPoints += numberOfPoints;
        if (numberOfPoints >= fullPoints)
        {
            //display something shiny
            //notify teacher ?
        }
    }
}
