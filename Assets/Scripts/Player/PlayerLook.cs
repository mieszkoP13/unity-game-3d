using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCam;
    private float xRotation = 0f;
    public float xSensivity = 30f;
    public float ySensivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate camera rotation on vertical axis
        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        // Apply calculations to the player camera
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate the player to look on horizontal axis
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensivity);
    }
}
