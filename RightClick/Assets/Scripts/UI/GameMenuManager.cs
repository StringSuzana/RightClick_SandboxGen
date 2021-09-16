using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    public void CloseMenu()
    {
        SceneManager.UnloadSceneAsync(SceneNames.Menu);
    }
}
