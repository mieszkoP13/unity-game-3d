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

    public PlayerData()
    {
        //level = SceneManager.GetActiveScene().buildIndex;
        health = GameManager.Instance.Health.health;

        position = new float[3];
        position[0] = GameManager.Instance.characterController.transform.position.x;
        position[1] = GameManager.Instance.characterController.transform.position.y;
        position[2] = GameManager.Instance.characterController.transform.position.z;
    }
}
