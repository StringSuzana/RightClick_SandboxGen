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


