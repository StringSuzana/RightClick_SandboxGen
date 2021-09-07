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
  
    [HideInInspector]
    public StudentInfo StudentInfo;

    [HideInInspector]
    public string hardcoded_student_name = "Suzy";

    public void SaveStudentInfo()
    {
        Debug.Log("save student info, total points: "+ this.StudentInfo.totalExtraPoints);
        SaveSystem.SavePlayerData(this);
    }
    public void LoadStudentInfo()
    {
        StudentInfo info = SaveSystem.LoadStudentData(this.hardcoded_student_name);
        Debug.Log("loaded points: " + info.totalExtraPoints);
        this.StudentInfo.studentName = info.studentName;
        this.StudentInfo.totalExtraPoints = info.totalExtraPoints;
    }

    public void SetExtraPoints(float points)
    {
        Debug.Log("SetExtraPoints: " + points);
        this.StudentInfo.totalExtraPoints = points;
    }
    public void AddExtraPoints(float points)
    {
        Debug.Log("AddExtraPoints: " + points);
        this.StudentInfo.totalExtraPoints += points;
        Debug.Log("Total points: " + this.StudentInfo.totalExtraPoints);
        SaveStudentInfo();
    }
}
