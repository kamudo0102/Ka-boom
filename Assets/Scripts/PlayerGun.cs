using Cinemachine;
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
    public float fireRate = 0.1f;
    private float timer;
    public Animator muzzleFlash;

    private CinemachineImpulseSource screenShaker;

    const float DEADZONE = 0.15f;

    private void Start()
    {
        screenShaker = FindAnyObjectByType<CinemachineImpulseSource>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if (Mathf.Abs(player.transform.position.x - worldMousePosition.x) > DEADZONE)
        {
            transform.right = direction * transform.localScale.x;

            if (worldMousePosition.x < player.transform.position.x)
            {
                // Change the scale of the GameObject to -1 on the x-axis.
                Vector3 newScale = transform.localScale;
                newScale.x = -1f;
                transform.localScale = newScale;
            }
            else
            {
                Vector3 newScale = transform.localScale;
                newScale.x = 1f;
                transform.localScale = newScale;
            }
        }

        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            timer = 0;
            Bullet bullet = Instantiate(bulletPrefab, gun.position, transform.rotation).GetComponent<Bullet>();

            direction = direction.normalized + new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));

            bullet.speed += transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude;
            bullet.direction = direction.normalized;
            bullet.transform.localScale = -transform.localScale;

            SoundManager.PlaySound(SoundManager.Sound.Gunshot);
            screenShaker.GenerateImpulse(direction.normalized * 0.007f);
            muzzleFlash.SetTrigger("Flash");
        }

        timer += Time.deltaTime;
    }
}
