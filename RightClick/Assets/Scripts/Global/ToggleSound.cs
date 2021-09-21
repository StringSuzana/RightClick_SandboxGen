using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    internal float currentState = 1;
    [SerializeField]
    private Image btnSound;

    [Tooltip("The volume when this sound button is toggled on")]
    public float volumeOn = 1;

    [Tooltip("The volume when this sound button is toggled off")]
    public float volumeOff = 0;

    void Awake()
    {
        currentState = PlayerPrefs.GetFloat(PlayerPrefNames.SoundVolume);
        SetSound();
    }

    void SetSound()
    {
        PlayerPrefs.SetFloat(PlayerPrefNames.SoundVolume, currentState);
        Color newColor = btnSound.material.color;
        if (currentState == volumeOn)
            newColor.a = 1;
        else
            newColor.a = 0.5f;
        btnSound.color = newColor;

        AudioManager.Instance.SetMusicVolume(currentState);
    }

    public void Toggle()
    {
        if (currentState == volumeOn) currentState = volumeOff;
        else currentState = volumeOn;
        SetSound();
    }

}
