using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSoundAndMusic : MonoBehaviour
{
    [SerializeField]
    private Canvas settingsMenu;

    [SerializeField]
    private Text musicText;
    [SerializeField]
    private Text soundText;

    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;
    private void Start()
    {
        var musicVolume = PlayerPrefs.GetFloat(PlayerPrefNames.MusicVolume, 1);
        var soundVolume = PlayerPrefs.GetFloat(PlayerPrefNames.SoundVolume, 1);
       
        print("music : " + musicVolume);
        print("sound : " + soundVolume);

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;

        musicText.text = Mathf.Round(musicVolume * 100) + "%";
        soundText.text = Mathf.Round(soundVolume * 100) + "%";

        settingsMenu.gameObject.SetActive(false);
    }
    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat(PlayerPrefNames.MusicVolume, musicSlider.value);
        musicText.text = Mathf.Round(musicSlider.value * 100) + "%";

        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }
    public void SetSoundsVolume()
    {
        PlayerPrefs.SetFloat(PlayerPrefNames.SoundVolume, soundSlider.value);
        soundText.text = Mathf.Round(soundSlider.value * 100) + "%";

        AudioManager.Instance.SetSoundsVolume(soundSlider.value);

    }
    public void CloseMenu()
    {
        settingsMenu.gameObject.SetActive(false);
    }
    public void OpenMenu()
    {
        settingsMenu.gameObject.SetActive(true);
    }
}
