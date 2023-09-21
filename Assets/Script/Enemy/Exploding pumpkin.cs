using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodingpumpkin : Enemy
{
    public GameObject explosion;

    public override void Update()
    {
        base.Update();

        if (Vector2.Distance(transform.position, Player.instance.transform.position) < 1.5f && !dead)
            OnDeath();
    }

    public override void DestroyThis()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        base.DestroyThis();
    }
}
