using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogue : MonoBehaviour
{
    private NPCScriptableObject npcScriptableObject;
    public GameObject dialogueMenu;
    public GameObject playerUI;
    public TMP_Text currentSpeaker;
    public TMP_Text dialogueText;
    private int currentDialogue = 0;

    public void InitDialogue(NPCScriptableObject _npcScriptableObject)
    {
        npcScriptableObject = _npcScriptableObject;
        currentSpeaker.text = "You";
        playerUI.SetActive(false);
        this.gameObject.SetActive(false);
        dialogueMenu.SetActive(true);
        Dialogue();
    }

    public void FinishDialogue()
    {
        dialogueMenu.SetActive(false);
        this.gameObject.SetActive(true);
        playerUI.SetActive(true);
    }

    public void Dialogue()
    {
        if(currentDialogue >= npcScriptableObject.dialogue.Length)
        {
            FinishDialogue();
        }
        else
        {
            if(currentDialogue % 2 == 0)
            {
                currentSpeaker.text = "You";
            }
            else
            {
                currentSpeaker.text = npcScriptableObject.name;
            }
            dialogueText.text = npcScriptableObject.dialogue[currentDialogue++];
        }
    }
}
