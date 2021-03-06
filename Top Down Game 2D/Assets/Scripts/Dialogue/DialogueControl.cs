using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    public bool isShowing; //se a janela esta visivel
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])//frase completa ?
        {
            if(index < sentences.Length - 1)//terminou todas as frase ?
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // terminou
            {
                EndSentence();
            }
        }
    }

    public void EndSentence()
    {
        speechText.text = "";
        index = 0;
        dialogueObj.SetActive(false);
        sentences = null;
        isShowing = false;
    }

    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
