using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUIManager : MonoBehaviour
{

    public void PLayHoverSound()
    {
        Debug.Log("play hover");
        AudioManager.instance.PlayOneTime(SoundNames.ButtonHover);
    }
    public void PLayClickSound()
    {
        AudioManager.instance.PlayOneTime(SoundNames.Click);
    }
}