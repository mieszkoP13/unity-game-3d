using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    //public int level;
    public float health;
    public float[] position;

    public PlayerData(CharacterController playerController)
    {
        //level = SceneManager.GetActiveScene().buildIndex;
        health = playerController.GetComponent<PlayerHealth>().health;

        position = new float[3];
        position[0] = playerController.transform.position.x;
        position[1] = playerController.transform.position.y;
        position[2] = playerController.transform.position.z;
    }
}
