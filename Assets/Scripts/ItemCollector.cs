using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ItemCollector : MonoBehaviour
{
    public int currentScore;
    public int highscore;
    public GameObject token;

    [SerializeField] private TextMeshProUGUI tokentext;
    [SerializeField] private TextMeshProUGUI highscoretext;
    public void Update()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();

        if (currentScore > PlayerPrefs.GetInt("Highscore",0))   
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            PlayerPrefs.Save();
        }

       
      
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Token"))
        {
            // Destroy token if collided
            Destroy(collision.gameObject);

            currentScore++;
  
            tokentext.text = currentScore.ToString();
        }
    }

}
