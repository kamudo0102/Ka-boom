using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endCurrentScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentScore"))
            endCurrentScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }   
    }
}
