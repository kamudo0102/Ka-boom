using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenehandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreText;
 
   

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

   

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
