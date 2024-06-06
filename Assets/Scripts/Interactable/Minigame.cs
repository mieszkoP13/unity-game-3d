using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : Interactable
{
    protected override void Interact()
    {
        GameManager.Instance.player.SetActive(false);
        GameManager.Instance.minigameUI.SetActive(true);
    }
}
