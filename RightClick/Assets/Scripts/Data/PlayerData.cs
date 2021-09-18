using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    public static PlayerData sharedInstance;

    private void Awake()
    {

        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    [HideInInspector]
    public StudentInfo StudentInfo;

    [HideInInspector]
    public string hardcoded_student_name = "Suzy";
    public void SavePlayersPosition()
    {
        //minus some random value to awoid collider triggers
        PlayerPrefs.SetFloat("Pos_x", playerTransform.position.x - 1);
        PlayerPrefs.SetFloat("Pos_y", playerTransform.position.y);
        PlayerPrefs.SetFloat("Pos_z", playerTransform.position.z);
    }
    public Vector3 LoadPlayersPosition()
    {
        return new Vector3(PlayerPrefs.GetFloat("Pos_x"), PlayerPrefs.GetFloat("Pos_y"), PlayerPrefs.GetFloat("Pos_z"));
    }
    public void SaveStudentInfo()
    {
        Debug.Log("save student info, total points: " + this.StudentInfo.totalExtraPoints);
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
