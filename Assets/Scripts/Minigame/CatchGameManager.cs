using UnityEngine;
using TMPro;

public class CatchGameManager : MonoBehaviour
{
    public GameObject fallingItemPrefab;
    public Transform fallingItemsContainer;
    public float spawnInterval = 1f;
    public TextMeshProUGUI scoreText;

    [HideInInspector] public int score = 0;
    public int fallingItemLimit = 30;
    [HideInInspector] public int fallingItemCount = 0;

    private float timer;

    [HideInInspector] public float rectTransformWidth;

    void Start()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        rectTransformWidth = rectTransform.rect.width;

        timer = spawnInterval;
        scoreText.text = "Score: " + score + " / " + fallingItemLimit;
    }

    void Update()
    {
        if(fallingItemCount > fallingItemLimit)
            FinishMinigame();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnFallingItem();
            timer = spawnInterval;
        }
    }

    void SpawnFallingItem()
    {
        GameObject fallingItem = Instantiate(fallingItemPrefab, Vector3.zero + new Vector3(Random.Range(-rectTransformWidth / 2, rectTransformWidth / 2), 0, 0), Quaternion.identity);
        fallingItem.transform.SetParent(fallingItemsContainer, false);
    }

    public void FinishMinigame()
    {
        GameManager.Instance.minigameUI.SetActive(false);
        GameManager.Instance.player.SetActive(true);
        GameManager.Instance.Health.RestoreHealth(score);
    }
}
