using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IEnterable
{
    public void Enter(string playerName);
}
public class DoorsToAnotherWorld : MonoBehaviour, IEnterable
{
    public Canvas InGameMenu;
    public bool isMenuVisible = false;
    void Start()
    {
        //InGameMenu = GetComponent<Canvas>();
        InGameMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void Enter(string playerName)
    {
        Debug.Log("Player: " + playerName + " wants to enter the door.");
        //SceneManager.LoadScene(SceneNames.start);
        InGameMenu.enabled = true;
        //InGameMenu.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D in doors");

        var playerObject = collision.gameObject.GetComponent(typeof(IPlayer)) as IPlayer;
        if (playerObject != null)
        {
            playerObject.OpenDoors(this);
        }
    }
}
