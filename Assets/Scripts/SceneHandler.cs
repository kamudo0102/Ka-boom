using System.Collections;
using System.Collections.Generic;
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
    

    bool isImageDisplay = false;

    [SerializeField]Canvas menusCanvas;

    [SerializeField] GameObject player;

    private void Start()
    {
      
       // keyboard.SetActive(false); mouse.SetActive(false);
        //player = GetComponent<GameObject>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
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
            enemy.SetActive(true);
            scareCrow.SetActive(false);
            menusCanvas.enabled = false;
            Instantiate(player, new Vector2(0,-3), transform.rotation);
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
