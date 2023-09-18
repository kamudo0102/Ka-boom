using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void TakeDamage()
    {
        health--;

        if (health <= 0)
            OnDeath();
    }

    public virtual void GetKnockBacked(Vector2 direction, float power)
    {
        StartCoroutine("Halt");
        rb.AddForce(direction * power, ForceMode2D.Impulse);
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    IEnumerator Halt()
    {
        GetComponent<AIPath>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<AIPath>().enabled = true;
    }
}
