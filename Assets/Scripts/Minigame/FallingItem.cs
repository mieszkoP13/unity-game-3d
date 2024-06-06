using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float fallSpeed = 5f;

    void Update()
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime, 0);

        if (transform.position.y < -Screen.height / 2)
        {
            Destroy(gameObject);
            GameManager.Instance.catchGameManager.fallingItemCount++;
        }
    }
}
