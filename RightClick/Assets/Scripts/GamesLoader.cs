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
    public void EnterMathQuiz()
    {
        SceneManager.LoadScene(SceneNames.mathQuiz);
    }
    public void No()
    {
        QuizMenu.enabled = false;
        //TODO
        //Move away from the collision area
        //disable moving character on button clicks
    }
}
