using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    void Start()
    {
        //Don't destroy this object when loading a new scene
        DontDestroyOnLoad(transform.gameObject);
    }

  
}
