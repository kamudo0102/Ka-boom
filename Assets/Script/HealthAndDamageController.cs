using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndDamageController : MonoBehaviour
{
    
    public float playerHealth;
    public float enemyDamage;
    [SerializeField]public Image[] hearts;

    private CinemachineImpulseSource screenShaker;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        screenShaker = FindAnyObjectByType<CinemachineImpulseSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damage();

            screenShaker.GenerateImpulse((collision.transform.position - transform.position).normalized * 0.1f);
        }
    }

    void Damage()
    {
        playerHealth -= enemyDamage;
        UpdateHealth();
        StartCoroutine("FreezeFrame");
        GetComponent<Animator>().SetTrigger("Hurt");
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

    IEnumerator FreezeFrame()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1;
    }
}
