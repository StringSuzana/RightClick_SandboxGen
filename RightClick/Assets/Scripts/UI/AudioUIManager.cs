using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUIManager : MonoBehaviour
{
    public void PLayHoverSound()
    {
        AudioManager.Instance.PlaySoundOneTime(SoundNames.ButtonHover);
    }
    public void PLayClickSound()
    {
        AudioManager.Instance.PlaySoundOneTime(SoundNames.Click);
    }

}