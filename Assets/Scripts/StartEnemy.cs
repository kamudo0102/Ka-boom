using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnemy : MonoBehaviour
{
    float delaytime = 1f;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            GetComponent<Animator>().SetTrigger("OnHit");
            Invoke("ReloadSceneMenu", delaytime);
            

        }
    }

    public void ReloadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }
}
