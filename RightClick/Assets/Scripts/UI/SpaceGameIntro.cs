using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGameIntro : MonoBehaviour, Interactable
{
    [SerializeField]
    private Dialogue gameIntro;
    [SerializeField]
    private AstronautMovement player;
    public void TriggerDialogue(Dialogue gameIntro)
    {
        Debug.Log(gameIntro.sentences.ToString());
        DialogManager.Instance.StartDialogue(gameIntro);
    }

    void Start()
    { 
       
        TriggerDialogue(gameIntro);
      
    }
     void Update()
    {
        if(!DialogManager.Instance.isOpened)
        {
            player.StartGame();
        }
    }

}
