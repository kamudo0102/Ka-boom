using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    
    public float playerHealth;
    [SerializeField] Image[] hearts;


    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }
    
    public void TakeDamage(int damage)
    {
       

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
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }

        }
       
    }
}
