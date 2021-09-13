using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //FIFO
    [SerializeField]
    private Queue<string> sentences;
    [SerializeField]
    private TextMeshProUGUI characterNameTextField;
    [SerializeField]
    private TextMeshProUGUI dialogTextField;

    private float letterTypingSpeed =0.05f;

    public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        characterNameTextField.SetText(dialogue.name);
        Debug.Log("sentences count before clear=>" + sentences.Count);

        sentences.Clear();
        Debug.Log("sentences count after clear=>" + sentences.Count);

        foreach (var sentence in dialogue.sentences)
        {
            Debug.Log("foreach=>"+sentence);
            sentences.Enqueue(sentence);
        }

        DisplayNextSentece();
    }

    public void DisplayNextSentece()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
        //dialogTextField.SetText(sentence);
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogTextField.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogTextField.text += letter;
            yield return new WaitForSecondsRealtime(letterTypingSpeed);
        }
        
    }


    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End conversation");
    }
}
