using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    
    [SerializeField] GameObject tutorialEnemy ;
    [SerializeField] GameObject activeEnemy;

    private void Start()
    {
        activeEnemy = Instantiate(tutorialEnemy, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

        if (activeEnemy == null) 
        {
            activeEnemy = Instantiate(tutorialEnemy, transform.position, transform.rotation);
            
        }
        
    }
}
