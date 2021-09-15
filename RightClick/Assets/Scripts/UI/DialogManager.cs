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
    private float letterTypingSpeed = 0.05f;
    [SerializeField]
    private Image image;
    private Animator animator;
    public bool isOpened = false;
    
    #region SINGLETON

    private static object m_Lock = new object();
    private static DialogManager m_Instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static DialogManager Instance
    {
        get
        {
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = (DialogManager)FindObjectOfType(typeof(DialogManager));
                }

                return m_Instance;
            }
        }
    }

    #endregion
 
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator = image.GetComponent<Animator>();
        if (isOpened)
        {
            EndDialogue();
        }
        isOpened = true;
        animator.SetBool("isOpen", isOpened);
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
        isOpened = false;
        animator.SetBool("isOpen", isOpened);
    }
}
