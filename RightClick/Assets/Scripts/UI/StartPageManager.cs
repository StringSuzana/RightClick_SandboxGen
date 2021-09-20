using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPageManager : MonoBehaviour
{
    [SerializeField]
    private Canvas howToMenu;
    private void Start()
    {
        howToMenu.gameObject.SetActive(false);
    }
    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneNames.GardenScene);
    }
    public void CloseHowToMenu()
    {
        howToMenu.gameObject.SetActive(false);
    }
    public void OpenHowToMenu()
    {
        howToMenu.gameObject.SetActive(true);
    }
}
