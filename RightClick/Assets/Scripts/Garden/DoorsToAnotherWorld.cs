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
    private Canvas menu;


    public void Enter(string playerName = null)
    {
        Debug.Log("Player: " + playerName + " wants to enter the door.");
        menu.enabled = true;
        Debug.Log("is menu enabled: " + menu.isActiveAndEnabled);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerObject = collision.gameObject.GetComponent(typeof(IPlayer)) as IPlayer;
        if (playerObject != null)
        {
            playerObject.OpenDoors(this);
        }
    }

}
