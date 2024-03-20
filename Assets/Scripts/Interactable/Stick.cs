using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : Interactable
{
    public Transform player;
    private PlayerInteract interact;
    
    // Start is called before the first frame update
    void Start()
    {
        interact = player.GetComponent<PlayerInteract>();
    }

    protected override void Interact()
    {
        interact.PickUp(transform);
    }
}
