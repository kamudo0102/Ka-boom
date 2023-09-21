using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthAndDamageController : MonoBehaviour
{
    
    public float playerHealth;
    public float enemyDamage;
    [SerializeField]public float screenDelayTime = 1f;
    [SerializeField]public Image[] hearts;

    private bool dead = false;
   

    private CinemachineImpulseSource screenShaker;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        screenShaker = FindAnyObjectByType<CinemachineImpulseSource>();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !dead)
        {
            Damage();

            screenShaker.GenerateImpulse((collision.transform.position - transform.position).normalized * 0.1f);

            if (playerHealth == 0 && !dead)
            {
                dead = true;
                SoundManager.PlaySound(SoundManager.Sound.playerDeath);
                GetComponent<Animator>().SetTrigger("Dead");
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    private void Update()
    {
        if (dead)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Damage()
    {
        playerHealth -= enemyDamage;
        StartCoroutine("FreezeFrame");
        GetComponent<Animator>().SetTrigger("Hurt");
        UpdateHealth();
        SoundManager.PlaySound(SoundManager.Sound.playerHurt);
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
