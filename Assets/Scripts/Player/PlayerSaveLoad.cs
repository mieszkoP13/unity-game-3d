using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour
{
    public void SavePlayer()
    {
        SaveSystem.SavePlayer();
    }

    public void LoadPlayer()
    {
        GameManager.Instance.characterController.enabled = false;
        PlayerData data = SaveSystem.LoadPlayer();

        GameManager.Instance.Health.health = data.health;
        GameManager.Instance.characterController.transform.position = new Vector3(data.position[0],data.position[1],data.position[2]);
        GameManager.Instance.characterController.enabled = true;
    }
}
