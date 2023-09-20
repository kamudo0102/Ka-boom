using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 mouseDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mouseDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x + rb.velocity.y));

        if (mouseDirection.y > Mathf.Abs(mouseDirection.x))
        {
            if (mouseDirection.x > 0)
            {
                animator.SetBool("UpRight", true);
                animator.SetBool("UpLeft", false);
                animator.SetBool("DownRight", false);
                animator.SetBool("DownLeft", false);
            }
            else
            {
                animator.SetBool("UpRight", false);
                animator.SetBool("UpLeft", true);
                animator.SetBool("DownRight", false);
                animator.SetBool("DownLeft", false);
            }
        }
        else
        {
            if (mouseDirection.x > 0)
            {
                animator.SetBool("UpRight", false);
                animator.SetBool("UpLeft", false);
                animator.SetBool("DownRight", true);
                animator.SetBool("DownLeft", false);
            }
            else
            {
                animator.SetBool("UpRight", false);
                animator.SetBool("UpLeft", false);
                animator.SetBool("DownRight", false);
                animator.SetBool("DownLeft", true);
            }
        }
    }
}
