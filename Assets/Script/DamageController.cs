using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] float enemyDamage;
    [SerializeField] HealthController health;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        health.playerHealth -= enemyDamage;
        health.UpdateHealth();
        gameObject.SetActive(false);
    }
}
