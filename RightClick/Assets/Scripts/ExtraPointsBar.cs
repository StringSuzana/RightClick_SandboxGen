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
        imageExtraPoints.value = extraPoints;
    }

    public void CompletedQuest(float numberOfPoints)
    {
        //increase extraPoints
        extraPoints += numberOfPoints;
        if (numberOfPoints >= fullPoints)
        {
            //display something shiny
            //notify teacher ?
        }
    }
}
