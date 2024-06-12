using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform startPoint;    // Starting position of the platform
    public Transform endPoint;      // Ending position of the platform
    public float speed = 2.0f;      // Speed of movement
    public bool moveAutomatically = true; // Whether the platform moves automatically or not

    private Vector3 _nextPosition;  // Next position to move towards
    private Vector3 _previousPosition; // Previous position of the platform

    [HideInInspector] public Vector3 velocity;

    void Start()
    {
        // Set the initial position of the platform
        transform.position = startPoint.position;
        _nextPosition = endPoint.position;
        _previousPosition = transform.position;
    }

    void Update()
    {
        if (moveAutomatically)
        {
            MovePlatform();
        }

        // Calculate velocity manually
        velocity = (transform.position - _previousPosition) / Time.deltaTime;
        _previousPosition = transform.position;
    }

    void MovePlatform()
    {
        // Move the platform towards the next position
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, speed * Time.deltaTime);

        // If the platform reaches the next position, set the next position accordingly
        if (Vector3.Distance(transform.position, _nextPosition) <= 0.01f)
        {
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

    private void OnTriggerEnter(Collider other)
    {
        //GameManager.Instance.player.transform.parent = transform;
        if(other.CompareTag("Player"))
            GameManager.Instance.Motor.SetCurrentPlatform(this);
    }
    private void OnTriggerExit(Collider other)
    {
        //GameManager.Instance.player.transform.parent = null;
        if(other.CompareTag("Player"))
            GameManager.Instance.Motor.SetCurrentPlatform(null);
    }
}
