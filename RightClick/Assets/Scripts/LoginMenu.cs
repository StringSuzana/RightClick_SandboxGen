using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LogIn()
    {
        Debug.Log("start game");
        SceneManager.LoadScene(SceneNames.start);
    }
}

public struct SceneNames
{
    public static string sample = "SampleScene";
    public static string login = "LoginScene";
    public static string start = "StartPageScene";
    public static string settings = "Settings";
    public static string menu = "Menu";
}
