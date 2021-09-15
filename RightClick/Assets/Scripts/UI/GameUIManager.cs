using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private Canvas ExitMenu;
    void Start()
    {
        ExitMenu = GameObject.FindGameObjectWithTag(CanvasNames.exitMenu).GetComponent<Canvas>();
        ExitMenu.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            Debug.Log("Quitting the Game");
            ExitMenu.enabled = !ExitMenu.enabled;
            Application.Quit();
        }
    }
}
public struct CanvasNames
{
    public static string exitMenu = "ExitMenu";
    public static string quizMenu = "QuizMenu";
}
