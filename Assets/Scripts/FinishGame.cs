using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : Interactable
{
    protected override void Interact()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
