using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static float PlayerHealth { get; set; } = 100f;

    public static void SaveHealth(float health)
    {
        PlayerHealth = health;
    }

    public static float LoadHealth()
    {
        return PlayerHealth;
    }
}
