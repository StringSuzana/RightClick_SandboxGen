using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{
    public void LogIn()
    {
        Debug.Log("start game");
        SceneManager.LoadScene(SceneNames.StartPageScene);
    }
}

public struct SceneNames
{
    public static string SampleScene = "SampleScene";
    public static string LoginScene = "LoginScene";
    public static string StartPageScene = "StartPageScene";
    public static string Settings = "Settings";
    public static string Menu = "Menu";
    public static string MathQuizScene = "MathQuizScene";
    public static string SpaceGameScene = "SpaceGameScene";
    public static string GardenScene = "GardenScene";

}
