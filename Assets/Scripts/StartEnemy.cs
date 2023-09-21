using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnemy : MonoBehaviour
{
    float delaytime = 1f;
    bool a = true;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            
            if(a == true)
            {
                a = false;
            Destroy(other.gameObject);
            GetComponent<Animator>().SetTrigger("OnHit");
            Invoke("ReloadSceneMenu", delaytime);
            }
            Destroy(other.gameObject);
        }
    }

    public void ReloadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }
}
