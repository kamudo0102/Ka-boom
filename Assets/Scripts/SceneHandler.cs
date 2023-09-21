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
    

    

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DisplayImage()
    {
        if (isImageDisplay == false)
        {
            keyboard.enabled = true; mouse.enabled = true;
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
