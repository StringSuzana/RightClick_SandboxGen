using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPC : MonoBehaviour
{

    [SerializeField]
    private Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var student = collision.gameObject.GetComponent(typeof(IPlayer)) as IPlayer;
        if (student != null)
        {
            student.TalkToNpc(this);
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);//TODO SINGLETON
    }


}
