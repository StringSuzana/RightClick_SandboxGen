using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPC : MonoBehaviour, Interactable
{

    [SerializeField]
    private Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var student = collision.gameObject.GetComponent(typeof(IPlayer)) as IPlayer;
        if (student != null)
        {
            student.OpenDialogBox(this);
            TriggerDialogue(dialogue);
        }
    }
    public void TriggerDialogue(Dialogue d)
    {
        FindObjectOfType<DialogManager>().StartDialogue(d);//TODO SINGLETON
    }


}
