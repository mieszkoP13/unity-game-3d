using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    private float timer = 0f;
    public float frequency = 1f;
    public float objectHeal = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.Health.RestoreHealth(objectHeal);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;

        if (timer >= frequency)
        {
            GameManager.Instance.Health.RestoreHealth(objectHeal);

            timer = 0f;
        }
    }
}
