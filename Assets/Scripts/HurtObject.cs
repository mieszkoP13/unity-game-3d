using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    private float timer = 0f;
    public float frequency = 1f;
    public float objectDamage = 10f;
    public Animator animator;
    public bool destroyObjectOnCollide = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(animator != null)
                animator.SetBool("attack2",true);

            GameManager.Instance.Health.TakeDamage(objectDamage);
        }
        if(destroyObjectOnCollide)
            Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(animator != null)
            animator.SetBool("attack2",false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= frequency)
            {
                GameManager.Instance.Health.TakeDamage(objectDamage);

                timer = 0f;
            }
        }
    }
}
