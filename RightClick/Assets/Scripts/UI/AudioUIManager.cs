using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUIManager : MonoBehaviour
{
    public void PLayHoverSound()
    {
        AudioManager.Instance.PlayOneTime(SoundNames.ButtonHover);
    }
    public void PLayClickSound()
    {
        AudioManager.Instance.PlayOneTime(SoundNames.Click);
    }
}