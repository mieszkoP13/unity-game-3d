using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform startPoint;    // Starting position of the enemy
    public Transform endPoint;      // Ending position of the enemy
    public float speed = 2.0f;      // Speed of movement
    public bool moveAutomatically = true; // Whether the enemy moves automatically or not

    private Vector3 _nextPosition;  // Next position to move towards

    void Start()
    {
        // Set the initial position of the enemy
        transform.position = startPoint.position;
        _nextPosition = endPoint.position;
    }

    void Update()
    {
        if (moveAutomatically)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        // Move the enemy towards the next position
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, speed * Time.deltaTime);

        // If the enemy reaches the next position, set the next position accordingly and rotate 180 degrees
        if (Vector3.Distance(transform.position, _nextPosition) <= 0.01f)
        {
            // Rotate 180 degrees
            transform.Rotate(0, 180, 0);

            // If the current position is the start point, move towards the end point
            if (transform.position == startPoint.position)
            {
                _nextPosition = endPoint.position;
            }
            // If the current position is the end point, move towards the start point
            else if (transform.position == endPoint.position)
            {
                _nextPosition = startPoint.position;
            }
        }
    }

    // This method can be called externally to start or stop the automatic movement
    public void SetAutoMovement(bool autoMove)
    {
        moveAutomatically = autoMove;
    }
}
