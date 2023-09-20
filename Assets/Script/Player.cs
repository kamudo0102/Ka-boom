using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement Adjusment")]
    [SerializeField]float acceleration = 10f;
    [SerializeField] float deacceleration = 1;
    [SerializeField]float speed = 5;

    [Header("Heart")]
    Vector2 velocity = Vector2.zero;
    Vector2 rawInput;

    bool canMove;

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        if(rawInput.magnitude > 0)
        {
            rawInput.Normalize();
            
        }

        velocity += rawInput * acceleration * Time.deltaTime;

        if (velocity.sqrMagnitude >  speed * speed) 
        {
            velocity.Normalize();
            velocity *= speed;
        }

        if (rawInput.sqrMagnitude == 0)
        {
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

        rb2D.velocity = velocity;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("");
        }
      
    }

  

    

    public void Die()
    {
        SceneManager.LoadScene(1);
    }
}


