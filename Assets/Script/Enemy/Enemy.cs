using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    private Rigidbody2D rb;
    public GameObject token;

    public bool dead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Update()
    {
        if (dead)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public virtual void TakeDamage()
    {
        health--;

        if (health <= 0 && !dead)
            OnDeath();

        GetComponent<Animator>().SetTrigger("Hurt");
    }

    public virtual void GetKnockBacked(Vector2 direction, float power)
    {
        rb.AddForce(direction * power, ForceMode2D.Impulse);
    }

    public virtual void OnDeath()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        Instantiate(token, transform.position, transform.rotation);
        EnemySpawner.Instance.enemiesKilled++;
    }

    public virtual void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void SetDead()
    {
        GetComponent<Animator>().SetBool("IsDead", true);
        dead = true;
    }
}
