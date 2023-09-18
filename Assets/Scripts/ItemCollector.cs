using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int tokenScore = 0;
    public GameObject token;

    [SerializeField] private TextMeshProUGUI tokentext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Token"))
        {
            // Destroy token if collided
            Destroy(collision.gameObject);

            tokenScore++;
            tokentext.text = "Score: " + tokenScore;
        }
    }
}
