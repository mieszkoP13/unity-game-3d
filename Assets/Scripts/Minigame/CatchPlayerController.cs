using UnityEngine;

public class CatchPlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float leftLimit;
    private float rightLimit;

    void Start()
    {
        Vector3[] worldCorners = new Vector3[4];
        GameManager.Instance.catchGameManager.GetComponent<RectTransform>().GetWorldCorners(worldCorners);
        leftLimit = worldCorners[0].x;
        rightLimit = worldCorners[2].x;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FallingItem"))
        {
            GameManager.Instance.catchGameManager.score++;
            GameManager.Instance.catchGameManager.scoreText.text = "Score: " + GameManager.Instance.catchGameManager.score + " / " + GameManager.Instance.catchGameManager.fallingItemLimit;;
            Destroy(other.gameObject);
            GameManager.Instance.catchGameManager.fallingItemCount++;
        }
    }
}
