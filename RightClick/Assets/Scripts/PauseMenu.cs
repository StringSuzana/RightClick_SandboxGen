using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseMenu;


    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }


    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }
    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }
}
