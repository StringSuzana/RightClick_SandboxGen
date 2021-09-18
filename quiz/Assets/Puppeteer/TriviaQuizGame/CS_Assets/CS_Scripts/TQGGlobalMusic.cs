//Version 1.99 (26.02.2018)

using UnityEngine;
using System.Collections;

namespace TriviaQuizGame
{
    /// <summary>
    /// handles a global music source which carries over from scene to scene without resetting the music track.
    /// You can have this script attached to a music object and include that object in each scene, and the script will keep
    /// only the oldest music source in the scene. If there is new music, it will crossfade and the replace the old one.
    /// </summary>
    public class TQGGlobalMusic : MonoBehaviour
    {
        [Tooltip("The tag of the music source")]
        public string musicTag = "Music";

        [Tooltip("The time this instance of the music source has been in the game")]
        internal float instanceTime = 0;
        internal bool destroyThis = false;

        internal GameObject[] musicObjects;
        internal AudioSource firstMusicObject;
        internal AudioSource secondMusicObject;

        void Awake()
        {
            //Find all the music objects in the scene
            musicObjects = GameObject.FindGameObjectsWithTag(musicTag);

            //Keep only the music object which has been in the game for more than 0 seconds
            if (musicObjects.Length > 1)
            {
                // Go through all the music objects in the scene, and check if there is new music playing
                foreach (var musicObject in musicObjects)
                {
                    // Organize the music objects from old to new
                    if (musicObject.GetComponent<TQGGlobalMusic>().instanceTime <= 0)    secondMusicObject = musicObject.GetComponent<AudioSource>();
                    else    firstMusicObject = musicObject.GetComponent<AudioSource>();

                    if (firstMusicObject && secondMusicObject)
                    {
                        // If the music didn't change, remove the new music object and keep playing the old one. Otherwise, if we have new music, cross-fade from the old music to the new one
                        if (firstMusicObject.clip == secondMusicObject.clip) Destroy(secondMusicObject.gameObject);
                        else StartCoroutine("CrossFade");

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Cross fades two music objects, lowering the volume of the old one, and increasing the volume of the new one
        /// </summary>
        /// <returns></returns>
        IEnumerator CrossFade()
        {
            float timeOut = 1;

            // Gradually cross-fade the music objects
            while (timeOut > 0)
            {
                // Reduce the volume of the first music object
                firstMusicObject.volume = timeOut;

                // Increase the volume of the second music object
                secondMusicObject.volume = 1 - timeOut;

                // Wait for update. This is used to allow animation
                yield return new WaitForSeconds(Time.deltaTime);

                timeOut -= Time.deltaTime;
            }

            // Remove the first music object as we don't need it anymore
            Destroy(firstMusicObject.gameObject);
        }

        void Start()
        {
            //Don't destroy this object when loading a new scene
            DontDestroyOnLoad(transform.gameObject);
        }

        private void Update()
        {
            instanceTime += Time.deltaTime;
        }

    }
}
