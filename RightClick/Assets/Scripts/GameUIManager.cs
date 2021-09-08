using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private Canvas ExitMenu;
    private bool isMenuVisible = false;
    void Start()
    {
        ExitMenu = GameObject.FindGameObjectWithTag(CanvasNames.exitMenu).GetComponent<Canvas>();
        ExitMenu.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitMenu.enabled = !ExitMenu.enabled;
            isMenuVisible = ExitMenu.enabled;
        }
    }
}
public struct CanvasNames
{
    public static string exitMenu = "ExitMenu";
    public static string quizMenu = "QuizMenu";
}
