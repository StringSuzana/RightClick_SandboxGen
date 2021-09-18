using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public interface IPlayer
{
    void OpenDoors(IEnterable doorsToAnotherWorld);
    void OpenDialogBox(Interactable interactable);
}
public class StudentPlayer : MonoBehaviour, IPlayer
{
    public void OpenDialogBox(Interactable interactable)
    {
        Debug.Log("Talking to NPC: ");
    }

    public void OpenDoors(IEnterable doorsToAnotherWorld)
    {
        Debug.Log("Player=> OpenDoors");
        //check some stuff
        doorsToAnotherWorld.Enter(PlayerData.sharedInstance.StudentInfo.studentName);
        //Player has encounter some enterable doors trigger
    }

}
