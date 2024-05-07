using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject playerUI;
    public GameObject cutsceneUI;
    public Camera mainCamera;
    public Camera cutsceneCamera;

    void Awake()
    {
        mainCamera.enabled = true;
        cutsceneCamera.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerUI.SetActive(false);
            cutsceneUI.SetActive(true);
            player.SetActive(false);
            mainCamera.enabled = false;
            cutsceneCamera.enabled = true;
            StartCoroutine(FinishCut());
        }
    }

    IEnumerator FinishCut()
    {
        while (!cutsceneCamera.GetComponent<MovingCamera>().pathFinished)
            yield return null;

        Destroy(gameObject);
        player.SetActive(true);
        cutsceneUI.SetActive(false);
        playerUI.SetActive(true);
        mainCamera.enabled = true;
        cutsceneCamera.enabled = false;
    }
}
