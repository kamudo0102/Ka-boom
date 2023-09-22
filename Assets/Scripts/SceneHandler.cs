using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenehandler : MonoBehaviour
{

    [SerializeField] GameObject keyboard;
    [SerializeField] GameObject mouse;
    [SerializeField] GameObject scareCrow;
    [SerializeField] GameObject enemy;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject background;
    bool isImageDisplay = false;

    [SerializeField]Canvas menusCanvas;

    [SerializeField] GameObject player;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DisplayImage()
    {
        if (isImageDisplay == false)
        {
            keyboard.SetActive(true); mouse.SetActive(true);
            background.SetActive(true);
            enemy.SetActive(true);
            scareCrow.SetActive(false);
            menusCanvas.enabled = false;
            Instantiate(player, new Vector2(0,-2f), transform.rotation);
            isImageDisplay = true;  
        }
        else if (isImageDisplay == true)
        {
            keyboard.SetActive(false); mouse.SetActive(false);
            isImageDisplay = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
