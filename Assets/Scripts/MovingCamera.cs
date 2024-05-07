using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypointPath;

    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    [HideInInspector]
    public bool pathFinished = false;

    void Start()
    {
        TargetNextWaypoint();
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        if (!pathFinished && elapsedPercentage >= 1)
            TargetNextWaypoint();
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.transform.GetChild(_targetWaypointIndex);
        _targetWaypointIndex = _targetWaypointIndex + 1;

        if(_targetWaypointIndex >= _waypointPath.transform.childCount)
        {
            pathFinished = true;
            return;
        }

        _targetWaypoint = _waypointPath.transform.GetChild(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }
}
