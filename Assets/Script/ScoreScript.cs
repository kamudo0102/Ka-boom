using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int _score;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentScoreText;
    // Start is called before the first frame update

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        if (PlayerPrefs.HasKey("CurrentScore"))
            currentScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
