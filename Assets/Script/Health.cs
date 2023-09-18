using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float maxhealth = 100;
    float currentHealth;
    [SerializeField] GameObject[] hearthImage = new GameObject[3]; 

    
    

    
    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }

    // Update is called once per frame
    void UpdateHealth()
    {
        float fillAmount = currentHealth / maxhealth;

        

              
    }
}
