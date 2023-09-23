using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Player.Prefs.SetInt("Variabelnamn", värde)
// Player.Prefs.GetInt("Variabelnamn")
public class PlayerGun : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform gun;
    float timer;
    public float fireRate = 0.1f;

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert the screen position to world position.
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (Mathf.Abs(player.transform.position.x - worldMousePosition.x) > 0.1f)
        {
            transform.right = direction * transform.localScale.x;

            // Check if the mouse is on the left side of the GameObject.
            if (worldMousePosition.x < player.transform.position.x)
            {
                // Change the scale of the GameObject to -1 on the x-axis.
                Vector3 newScale = transform.localScale;
                newScale.x = -1f;
                transform.localScale = newScale;
            }
            else
            {
                // Reset the scale to its original state (1 on the x-axis).
                Vector3 newScale = transform.localScale;
                newScale.x = 1f;
                transform.localScale = newScale;
            }
        }
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            SoundManager.PlaySound(SoundManager.Sound.Gunshot);
            timer = 0;
            Bullet bullet = Instantiate(bulletPrefab, gun.position, transform.rotation).GetComponent<Bullet>();

            bullet.speed += transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude;

            bullet.direction = direction.normalized;
            bullet.transform.localScale = -transform.localScale;
        }

        timer += Time.deltaTime;
    }
}
