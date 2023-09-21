using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenehandler : MonoBehaviour
{

    [SerializeField] Image keyboard;
    [SerializeField] Image mouse;

    bool isImageDisplay = false;

    [SerializeField]Canvas menusCanvas;

    [SerializeField] GameObject player;

    private void Start()
    {

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
            keyboard.enabled = true; mouse.enabled = true;
            menusCanvas.enabled = false;
            Instantiate(player, new Vector2(0,-3), transform.rotation);
            isImageDisplay = true;  
        }
        else if (isImageDisplay == true)
        {
            keyboard.enabled = false; mouse.enabled = false;
            isImageDisplay = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
