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
    //public Transform planet;
    public Transform player;
    [SerializeField]
    private Dialogue dialogue;
    private bool hasBeenOpened = false;
    private void Start()
    {
       
    }
    public void TriggerDialogue(Dialogue d)
    {
        if (DialogManager.Instance.isOpened == false)
        {
            DialogManager.Instance.StartDialogue(d);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float playerYSize = player.GetComponent<SpriteRenderer>().size.y;
        float spriteBottomDistance = distance - playerYSize;
        if (!this.hasBeenOpened && spriteBottomDistance <= radius)
        {
            if (DialogManager.Instance.isOpened)
            {
                DialogManager.Instance.EndDialogue();
            }
            TriggerDialogue(dialogue);
            hasBeenOpened = true;
        }
        else if (DialogManager.Instance.isOpened
            && spriteBottomDistance > 2f && spriteBottomDistance <2.1f)
        {
            DialogManager.Instance.EndDialogue();
        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}