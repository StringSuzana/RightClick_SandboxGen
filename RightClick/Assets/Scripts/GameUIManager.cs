using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public Canvas InGameMenu;
    public bool isMenuVisible = false;
    void Start()
    {
        InGameMenu = GetComponent<Canvas>();
        InGameMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameMenu.enabled = !InGameMenu.enabled;
            isMenuVisible = InGameMenu.enabled;
        }
    }
}
