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
    public Animator imageWithAnimator;
    public bool isOpened = false;
    
    #region SINGLETON
    // Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static DialogManager m_Instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static DialogManager Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(DialogManager) +
                    "' already destroyed. Returning null.");
                return null;
            }

            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = (DialogManager)FindObjectOfType(typeof(DialogManager));
                    if (m_Instance == null)
                    {
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<DialogManager>();
                        singletonObject.name = typeof(DialogManager).ToString() + " (Singleton)";
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return m_Instance;
            }
        }
    }
    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }


    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }

    #endregion
 
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        if (isOpened)
        {
            EndDialogue();
        }
        isOpened = true;
        imageWithAnimator.SetBool("isOpen", isOpened);
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
        imageWithAnimator.SetBool("isOpen", isOpened);
    }
}
