using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.mainCamera.enabled = true;
        GameManager.Instance.cutsceneCamera.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.playerUI.SetActive(false);
            GameManager.Instance.cutsceneUI.SetActive(true);
            GameManager.Instance.player.SetActive(false);
            GameManager.Instance.mainCamera.enabled = false;
            GameManager.Instance.cutsceneCamera.enabled = true;
            StartCoroutine(FinishCut());
        }
    }

    IEnumerator FinishCut()
    {
        while (!GameManager.Instance.cutsceneCamera.GetComponent<MovingCamera>().pathFinished)
            yield return null;

        Destroy(gameObject);
        GameManager.Instance.player.SetActive(true);
        GameManager.Instance.cutsceneUI.SetActive(false);
        GameManager.Instance.playerUI.SetActive(true);
        GameManager.Instance.mainCamera.enabled = true;
        GameManager.Instance.cutsceneCamera.enabled = false;
    }
}
