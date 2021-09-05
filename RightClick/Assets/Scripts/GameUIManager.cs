using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private Canvas ExitMenu;
    public bool isMenuVisible = false;
    void Start()
    {
        ExitMenu = GameObject.FindGameObjectWithTag(CanvasNames.exitMenu).GetComponent<Canvas>();
        ExitMenu.enabled = false;
    }

    // Update is called once per frame
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
}
