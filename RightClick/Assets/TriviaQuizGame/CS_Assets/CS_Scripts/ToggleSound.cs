//Version 1.65 (10.08.2016)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TriviaQuizGame.Types
{
   
    public class ToggleSound : MonoBehaviour
    {
        public Transform audioManagerObject;

        public string playerPref = "SoundVolume";

        // The index of the current value of the sound
        internal float currentState = 1;

        [Tooltip("The volume when this sound button is toggled on")]
        public float volumeOn = 1;

        [Tooltip("The volume when this sound button is toggled off")]
        public float volumeOff = 0;

        void Awake()
        {
            if (!audioManagerObject) audioManagerObject = AudioManager.Instance.transform;

            // Get the current state of the sound from PlayerPrefs
            if (audioManagerObject)
                currentState = PlayerPrefs.GetFloat(playerPref, audioManagerObject.GetComponent<AudioSource>().volume);
            else
                currentState = PlayerPrefs.GetFloat(playerPref, currentState);

            SetSoundVolume();
        }

        void SetSoundVolume()
        {
            if (!audioManagerObject) audioManagerObject = AudioManager.Instance.transform;

            PlayerPrefs.SetFloat(playerPref, currentState);
            Color newColor = GetComponent<Image>().material.color;

            // Update the graphics of the button image to fit the sound state
            if (currentState == volumeOn)
                newColor.a = 1;
            else
                newColor.a = 0.5f;

            GetComponent<Image>().color = newColor;

            // Set the value of the sound state to the source object
            if (audioManagerObject)
                audioManagerObject.GetComponent<AudioSource>().volume = currentState;
        }

        void Toggle()
        {
            if (currentState == volumeOn) currentState = volumeOff;
            else currentState = volumeOn;
            SetSoundVolume();
        }

        void StartSound(string sound)
        {
            if (audioManagerObject)
                AudioManager.Instance.Play(sound);
        }
    }
}