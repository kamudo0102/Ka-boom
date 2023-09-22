using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endCurrentScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentScore"))
            endCurrentScore.text = "Current Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
