using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] float turretRotationSpeed = 5f;

    private Gun currentGun;
    private float fireRate;
    private float fireRateDelta;

    public Vector3 aimOffset = Vector3.zero; // Offset to adjust aim

    private void Start()
    {
        currentGun = GetComponentInChildren<Gun>();
        fireRate = currentGun.GetRateOfFire();
    }

    private void Update()
    {
        Vector3 playerPos = GameManager.Instance.player.transform.position + aimOffset;
        
        // Check if player is not in range
        if(Vector3.Distance(transform.position, playerPos) > turretRange)
        {
            return; // Do nothing because player is not in range
        }

        // PLAYER IN RANGE

        // Rotate Turret towards player
        Vector3 playerDirection = playerPos - transform.position;
        float turretRotationStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, turretRotationStep, 0f);
        transform.rotation = Quaternion.LookRotation(newLookDirection);

        // Fire at the player if fire rate allows
        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta <= 0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange); //Show a gizmo when selected
    }
}