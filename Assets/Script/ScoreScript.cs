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
        currentScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        highScoreText.text = PlayerPrefs.GetInt("Highscore",0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
