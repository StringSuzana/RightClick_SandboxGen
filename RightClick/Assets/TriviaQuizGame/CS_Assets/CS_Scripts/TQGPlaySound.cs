using UnityEngine;

namespace TriviaQuizGame
{
	/// <summary>
	/// Plays a sound from an audio source.
	/// </summary>
	public class TQGPlaySound:MonoBehaviour
	{
		// The sound to play
		public AudioClip sound;
	
		public string soundSourceTag = "Sound";
		public bool playOnStart = true;

		void Start()
		{
			if( playOnStart == true )    PlaySound();
		}
		public void PlaySound()
		{
			// If there is a sound source tag and audio to play, play the sound from the audio source based on its tag
			if ( soundSourceTag != string.Empty && sound ) 
			{
				// Play the sound
				GameObject.FindGameObjectWithTag(soundSourceTag).GetComponent<AudioSource>().PlayOneShot(sound);
			}	
		}
	}
}