using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndDamageController : MonoBehaviour
{
    
    public float playerHealth;
    public float enemyDamage;
    [SerializeField]public Image[] hearts;


    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        playerHealth -= enemyDamage;
        UpdateHealth();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            //Invoke.Scenmanagement(HighScore);
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth )
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
       
    }
}
