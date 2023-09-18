using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Adjusment")]
    [SerializeField]float acceleration = 10f;
    [SerializeField] float deacceleration = 4;
    [SerializeField]float speed = 5;

    Vector2 velocity = Vector2.zero;
    Vector2 position;
    Vector2 rawInput;


    // Start is called before the first frame update
    void Start()
    {
        
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

        if(rawInput.sqrMagnitude== 0)
        {
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

        position += velocity * Time.deltaTime;
        transform.position = position;

    }
}
