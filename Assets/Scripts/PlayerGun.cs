using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gun;
    float timer;
    float fireRate = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.right = direction;

        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            timer = 0;
            Bullet bullet = Instantiate(bulletPrefab, gun.position, transform.rotation).GetComponent<Bullet>();

            bullet.speed += transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude;
        }

        timer += Time.deltaTime;
    }
}
