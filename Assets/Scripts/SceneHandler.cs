using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenehandler : MonoBehaviour
{

    [SerializeField] Image keyboard;
    [SerializeField] Image mouse;

    
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //public void HowToPlay()
    //{
      
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
