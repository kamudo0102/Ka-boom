using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gun;
    float timer;
    float fireRate = 0.1f;

    //public Transform targetObject; // Reference to the GameObject whose left side will trigger the scale change.
    //public float scaleValue = -1f;  // The scale value to set when the collision occurs.

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.right = direction;

        // Check if the GameObject's x-coordinate is less than or equal to the targetObject's left side.
        /*if (transform.position.x <= targetObject.position.x)
        {
            // Change the scale of the GameObject on the x-axis.
            Vector3 newScale = transform.localScale;
            newScale.x = scaleValue;
            transform.localScale = newScale;
        }*/

        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            timer = 0;
            Bullet bullet = Instantiate(bulletPrefab, gun.position, transform.rotation).GetComponent<Bullet>();

            bullet.speed += transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude;

            bullet.direction = direction.normalized;
        }

        timer += Time.deltaTime;
    }
}
