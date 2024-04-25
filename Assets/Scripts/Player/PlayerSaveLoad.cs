using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour
{
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(controller);
    }

    public void LoadPlayer()
    {
        controller.enabled = false;
        PlayerData data = SaveSystem.LoadPlayer();

        controller.GetComponent<PlayerHealth>().health = data.health;
        controller.transform.position = new Vector3(data.position[0],data.position[1],data.position[2]);
        controller.enabled = true;
    }
}
