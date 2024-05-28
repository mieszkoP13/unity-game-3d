using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : Interactable
{
    protected override void Interact()
    {
        GameManager.Instance.Interact.PickUp(transform);
    }
}
