using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Vector2 mouseDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        mouseDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

        if (mouseDirection.y > Mathf.Abs(mouseDirection.x))
        {
            // Looking Up
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
            // Looking Down
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
