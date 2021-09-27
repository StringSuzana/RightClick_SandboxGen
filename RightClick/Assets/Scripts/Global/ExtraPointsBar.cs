using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraPointsBar : MonoBehaviour
{
    [SerializeField]
    private Slider imageExtraPoints;

    [Tooltip("Current number of points.")]
    private float extraPoints;
    [Tooltip("Total number of points that fit into points bar. Might be max points before alerting teacher with scores.")]
    private readonly float fullPoints = 5000f;

    void Start()
    {
        //imageExtraPoints = GameObject.FindGameObjectWithTag("ExtraPointsBar").GetComponent<Slider>();
        PlayerData.sharedInstance.LoadStudentInfo();
        Display();
    }

    private void Display()
    {
        imageExtraPoints.maxValue = fullPoints;
        imageExtraPoints.value = PlayerData.sharedInstance.StudentInfo.totalExtraPoints;
    }
}
