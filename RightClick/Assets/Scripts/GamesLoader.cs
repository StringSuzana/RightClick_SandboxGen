using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesLoader : MonoBehaviour
{
    public Canvas gamesMenu;
    public Canvas quizMenu;
    private void Start()
    {
        gamesMenu.enabled = false;
        quizMenu.enabled = false;
    }
    private void Update()
    {
        if (quizMenu.enabled || gamesMenu.enabled)
        {
            //Pause the game (freeze the time)
            Time.timeScale = 0f;
        }
    }
    public void EnterMathQuiz()
    {
        quizMenu.enabled = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.mathQuiz);
    }
    public void EnterSpaceGame()
    {
        gamesMenu.enabled = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.spaceGame);
    }
    public void No()
    {
        gamesMenu.enabled = false;
        quizMenu.enabled = false;
        Time.timeScale = 1f;

        //TODO
        //Move player away from the collision area
        //disable moving character on button clicks
    }
}
