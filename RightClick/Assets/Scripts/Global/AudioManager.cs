using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TriviaQuizGame;

public class AudioManager : MonoBehaviour
{
    internal bool isPaused = false;

    [Tooltip("The volume when this sound button is toggled on")]
    public float volumeOn = 1;
    [Tooltip("The volume when this sound button is toggled off")]
    public float volumeOff = 0;

    public Sound[] music;
    public Sound[] sounds;
    public static AudioManager Instance;
    void Awake()
    {
        #region SINGLETON
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion


        foreach (var m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.audioClip;
            m.source.volume = PlayerPrefs.GetFloat(PlayerPref.MusicVolume);
            m.source.pitch = m.pitch;
            m.source.loop = true;
        }
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = PlayerPrefs.GetFloat(PlayerPref.SoundVolume);
            s.source.pitch = s.pitch;
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        PlayMusic(MusicNames.Bacground);
    }
    public void PlaySoundOneTime(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioClip not found => maybe the name in inspector is wrong or it is not there");
            return;
        }
        s.source.volume = PlayerPrefs.GetFloat(PlayerPref.SoundVolume);
        s.source.PlayOneShot(s.audioClip);
    }

    public void PlayMusic(string name)
    {
        Sound m = Array.Find(music, song => song.name == name);
        if (m == null)
        {
            Debug.Log("Sound not found => maybe the name in inspector is wrong or it is not there");
            return;
        }
        m.source.volume = PlayerPrefs.GetFloat(PlayerPref.MusicVolume);
        m.source.Play();
    }

    public void PlayTransition(string songName, float transitionTime)
    {
        StartCoroutine(CrossFadeAudio(songName, transitionTime));
    }

    public IEnumerator CrossFadeAudio(string songName, float transitionTime)
    {
        Sound song = Array.Find(music, m => m.name == songName);
        if (song == null)
        {
            Debug.Log("AudioClip not found => maybe the name in inspector is wrong or it is not there=> " + songName);
            yield return null;
        }
        float timeOut = 1;
        while (timeOut > 0)
        {
            foreach (var m in music)
            {
                if (m?.source.isPlaying == true)
                {
                    m.source.volume = timeOut;
                    if (timeOut - transitionTime <= 0)
                    {
                        Debug.Log("Stopped playing: " + m.source.name);
                        m.source.Stop();
                    }
                }
            }
            if ((1 - timeOut) <= PlayerPrefs.GetFloat(PlayerPref.MusicVolume))
            {
                song.source.volume = (1 - timeOut);
            }
            else
            {
                song.source.volume = PlayerPrefs.GetFloat(PlayerPref.MusicVolume);

            }
            if (!song.source.isPlaying)
            {
                song.source.Play();
            }

            yield return new WaitForSeconds(transitionTime);
            timeOut -= transitionTime;
        }
    }

    public void StopAllSounds()
    {
        foreach (var s in sounds)
        {
            if (s?.source.isPlaying == true)
            {
                s.source.Stop();
            }
        }
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(PlayerPref.MusicVolume, value);
        foreach (var m in music)
        {
            m.source.volume = value;
        }
    }

    public void SetSoundsVolume(float value)
    {
        PlayerPrefs.SetFloat(PlayerPref.SoundVolume, value);
        foreach (var s in sounds)
        {
            s.source.volume = value;
        }
    }
}
