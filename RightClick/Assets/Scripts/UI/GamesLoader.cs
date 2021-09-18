using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesLoader : MonoBehaviour
{
    [SerializeField]
    private Canvas gamesMenu;
    [SerializeField]
    private Canvas quizMenu;
    [SerializeField]
    private Animator fadeTransition;
    private float transitionTime = .2f;

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
        AudioManager.Instance.PlayTransition(SoundNames.RelaxedSpaceMusic, transitionTime);
        StartCoroutine(FadeScene(SceneNames.MathQuizScene));

    }
    public void EnterSpaceGame()
    {
        gamesMenu.enabled = false;
        Time.timeScale = 1f;
        AudioManager.Instance.PlayTransition(SoundNames.RelaxedSpaceMusic, transitionTime);
        // StartCoroutine(AudioManager.instance.CrossFadeAudio
        StartCoroutine(FadeScene(SceneNames.SpaceGameScene));
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

    public IEnumerator FadeScene(string sceneName)
    {
        fadeTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
