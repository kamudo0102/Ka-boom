using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnemy : MonoBehaviour
{
  
    [SerializeField]GameObject enemy;

    public bool a  = true;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if (a == true)
            {
                a = false;

                animator.SetTrigger("OnHit");

            }
            
            Destroy(other.gameObject);
        }


    }

    public void Destroy()
    {
        Destroy(gameObject);

    
    }

    public void ReloadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }
}
