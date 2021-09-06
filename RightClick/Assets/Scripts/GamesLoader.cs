using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesLoader : MonoBehaviour
{
    public Canvas QuizMenu;
    private void Start()
    {
        QuizMenu.enabled = false;
    }
    private void Update()
    {
        if (QuizMenu.enabled == true)
        {
            //Pause the game (freeze the time)
            Time.timeScale = 0f;
        }
    }
    public void EnterMathQuiz()
    {
        QuizMenu.enabled = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.mathQuiz);
    }
    public void No()
    {
        QuizMenu.enabled = false;
        Time.timeScale = 1f;

        //TODO
        //Move away from the collision area
        //disable moving character on button clicks
    }
}
