using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface IGame
{
    IEnumerator GameOver(float delay);
    IEnumerator Victory(float delay);
    void ContinueToPreviousScene();
    void Restart();
    void LandedOnWrongPlanet();
}
public class SpaceGame : MonoBehaviour, IGame
{
    private EventSystem eventSystem;

    [Header("Player")]
    [SerializeField]
    private AstronautMovement astronaut;
    [SerializeField]
    private int lives = 3;
    [Tooltip("The image that displays how many lives the player has left")]
    [SerializeField]
    private Image livesBar;

    private int score = 90;
    private float livesBarWidth;

    [Header("Canvases")]
    [SerializeField]
    private Transform gameOverCanvas;
    [SerializeField]
    private Transform victoryCanvas;

    [Header("Sounds")]
    private Sound[] sounds;
    [SerializeField]
    private Sound Background;
    [SerializeField]
    private Sound soundGameOver;
    [SerializeField]
    private Sound soundWrong;
    [SerializeField]
    private Sound soundVictory;
    [SerializeField]
    private Sound soundDissolve;
    [SerializeField]
    private Sound soundRespawning;

    //[SerializeField]
    //private AnimationClip animationTrust;
    void Start()
    {
        eventSystem = EventSystem.current;

        sounds = new Sound[] { Background, soundGameOver, soundDissolve, soundRespawning, soundWrong, soundVictory };
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        if (gameOverCanvas) gameOverCanvas.gameObject.SetActive(false);
        if (victoryCanvas) victoryCanvas.gameObject.SetActive(false);

        livesBarWidth = livesBar.rectTransform.sizeDelta.x / lives;

    }

    public IEnumerator GameOver(float delay)
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(delay);
        if (gameOverCanvas)
        {
            PlayerPrefs.GetFloat(PlayerPref.volumeScale);
            gameOverCanvas.gameObject.SetActive(true);
            if (soundGameOver != null) soundGameOver.source.PlayOneShot(soundGameOver.audioClip, PlayerPrefs.GetFloat(PlayerPref.volumeScale));
        }
    }
    public IEnumerator Victory(float delay)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(delay);
        if (victoryCanvas)
        {
            victoryCanvas.gameObject.SetActive(true);
            if (victoryCanvas.Find("BG/CompletePanel/ScoreText/SoreNumbers"))
                victoryCanvas.Find("BG/CompletePanel/ScoreText/SoreNumbers").GetComponent<Text>().text = score.ToString();

            PlayerData.sharedInstance.AddExtraPoints(score);

            if (soundVictory != null) soundVictory.source.PlayOneShot(soundVictory.audioClip, PlayerPrefs.GetFloat(PlayerPref.volumeScale));

        }
    }

    public void UpdateLivesBar()
    {
        if (livesBar)
        {
            livesBar.rectTransform.sizeDelta = Vector2.Lerp(livesBar.rectTransform.sizeDelta, new Vector2(lives * livesBarWidth, livesBar.rectTransform.sizeDelta.y), 1);
        }
        if (lives <= 0) StartCoroutine(GameOver(1));

    }

    public void LandedOnWrongPlanet()
    {
        lives -= 1;
        UpdateScore();
    }
    public void Died()
    {
        print("died");
        lives -= 1;
        UpdateScore();
        if (lives > 0)
            Respawn();

    }
    private void UpdateScore()
    {
        score = 30 * lives;
        UpdateLivesBar();
    }

    void Respawn()
    {
        //Play sound
        PlayRespawningSound();
        StopAllCoroutines();
        StartCoroutine(astronaut.FadeIn());
    }

    void PlayRespawningSound()
    { 
        if (soundRespawning != null) soundRespawning.source.PlayOneShot(soundRespawning.audioClip, PlayerPrefs.GetFloat(PlayerPref.volumeScale));
        
    }
    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ContinueToPreviousScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneNames.GardenScene);
    }

}
