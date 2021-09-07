using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public static void SavePlayerData(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player_" + data.StudentInfo.studentName + ".rightclick";
        FileStream stream = new FileStream(path, FileMode.Create);
        StudentInfo studentInfo = new StudentInfo(data);
        formatter.Serialize(stream, studentInfo);
        stream.Close();

        Debug.Log(path);

    }
    public static StudentInfo LoadStudentData(string playerName)
    {
        string path = Application.persistentDataPath + "/player_" + playerName + ".rightclick";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            StudentInfo studentInfo = formatter.Deserialize(stream) as StudentInfo;
            stream.Close();

            return studentInfo;
        }
        else
        {
            Debug.LogError("File not found.");
            return null;
        }
    }
}
