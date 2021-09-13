using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface Interactable
{
    public void TriggerDialogue(Dialogue d);
}

public class PlanetNPC : MonoBehaviour, Interactable
{
    public float radius;
    public Transform interactionTransform;
    public Transform player;
    [SerializeField]
    private Dialogue dialogue;
    private bool hasBeenOpened = false;
    public void TriggerDialogue(Dialogue d)
    {
        FindObjectOfType<DialogManager>().StartDialogue(d);//TODO SINGLETON
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (!hasBeenOpened && distance <= radius)
        {
            TriggerDialogue(dialogue);
            //hasBeenOpened = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}