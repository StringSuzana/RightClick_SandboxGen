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

    [SerializeField]
    private  Canvas quizMenu;


    public void Enter(string playerName)
    {
        Debug.Log("Player: " + playerName + " wants to enter the door.");
        quizMenu.enabled = true;
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
