using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Change to bullet
        {
            enemy.TakeDamage();
            enemy.GetKnockBacked((transform.position - collision.transform.position).normalized, 5);

            if (collision.gameObject.GetComponent<Bullet>() != null)
                Destroy(collision.gameObject);
        }
    }
}
