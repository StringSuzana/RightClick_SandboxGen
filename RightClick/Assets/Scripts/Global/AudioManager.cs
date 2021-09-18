using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TriviaQuizGame;

public class AudioManager : MonoBehaviour
{
    internal float soundPlayTime = 0;
    internal bool isPaused = false;

    [Tooltip("The index of the current value of the sound")]
    internal float currentState = 1;

    [Tooltip("The volume when this sound button is toggled on")]
    public float volumeOn = 1;
    [Tooltip("The volume when this sound button is toggled off")]
    public float volumeOff = 0;

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

        DontDestroyOnLoad(gameObject);
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        Play(SoundNames.Bacground);
    }
    public void PlayOneTime(string name)
    {
        Debug.Log(name);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioClip not found => maybe the name in inspector is wrong or it is not there");
            return;
        }
        s.source.PlayOneShot(s.audioClip);
    }
    public void PlayOneTime(string name, float volumeScale)
    {
        Debug.Log(name);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioClip not found => maybe the name in inspector is wrong or it is not there");
            return;
        }
        s.source.PlayOneShot(s.audioClip, volumeScale);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found => maybe the name in inspector is wrong or it is not there");
            return;
        }
        s.source.Play();
    }

    public void PlayTransition(string newSoundName, float transitionTime)
    {
        StartCoroutine(CrossFadeAudio(newSoundName, transitionTime));
    }

    public IEnumerator CrossFadeAudio(string newSoundName, float transitionTime)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == newSoundName);
        if (sound == null)
        {
            Debug.Log("AudioClip not found => maybe the name in inspector is wrong or it is not there=> " + newSoundName);
            yield return null;
        }
        float timeOut = 1;
        while (timeOut > 0)
        {
            foreach (var s in sounds)
            {
                if (s?.source.isPlaying == true)
                {
                    s.source.volume = timeOut;
                    Debug.Log(s?.source.name + " is playing " + s?.source.clip.name);
                    if (timeOut - transitionTime <= 0 )
                    {
                        Debug.Log("Stopped playing: " + s.source.name);
                        s.source.Stop();
                        
                    }
                }
            }
            sound.source.volume = 1 - timeOut;
            sound.source.Play();

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

    public void SetNewVolume(float newVolume)
    {
        currentState = newVolume;
        PlayerPrefs.SetFloat(PlayerPref.volumeScale, currentState);
        foreach (var s in sounds)
        {
            s.source.volume = newVolume;
        }
    }
}
