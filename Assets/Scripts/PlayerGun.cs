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
            Instantiate(bulletPrefab, gun.position, transform.rotation);
        }

        timer += Time.deltaTime;
    }
}
