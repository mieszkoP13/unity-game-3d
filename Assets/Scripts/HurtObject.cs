using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    private float timer = 0f;
    public float frequency = 1f;
    public float objectDamage = 10f;
    public Animator animator;
    PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(animator != null)
                animator.SetBool("attack2",true);

            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(objectDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(animator != null)
            animator.SetBool("attack2",false);

        playerHealth = null;
    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;

        if (timer >= frequency)
        {
            if(playerHealth != null)
                playerHealth.TakeDamage(objectDamage);

            timer = 0f;
        }
    }
}
