using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : Interactable
{
    public Transform player;
    public NPCScriptableObject npcScriptableObject;
    private PlayerDialogue playerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        playerDialogue = player.GetComponent<PlayerDialogue>();
    }

    protected override void Interact()
    {
        playerDialogue.InitDialogue(npcScriptableObject);
    }
}
