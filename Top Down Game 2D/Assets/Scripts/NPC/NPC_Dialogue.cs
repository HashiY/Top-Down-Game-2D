using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogueS;

    bool playerHit;

    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for(int i=0; i < dialogueS.dialogues.Count; i++)
        {
            sentences.Add(dialogueS.dialogues[i].sentence.portuguese);
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogueObj.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
