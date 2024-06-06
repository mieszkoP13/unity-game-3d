using UnityEngine;

public class CatchPlayerController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
        
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 0, GameManager.Instance.catchGameManager.rectTransformWidth*2);
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
