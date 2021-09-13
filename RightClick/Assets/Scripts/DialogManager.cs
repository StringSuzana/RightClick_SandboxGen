using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private Queue<string> sentences;//FIFO
    [SerializeField]
    private TextMeshProUGUI characterNameTextField;
    [SerializeField]
    private TextMeshProUGUI dialogTextField;
    private float letterTypingSpeed =0.05f;
    public Animator imageWithAnimator;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        imageWithAnimator.SetBool("isOpen", true);
        characterNameTextField.SetText(dialogue.name);
        sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
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
        imageWithAnimator.SetBool("isOpen", false);
    }
}
