using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private Vector2 lastFramePosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Vector2)transform.position - lastFramePosition != Vector2.zero)
            moveDirection = ((Vector2)transform.position - lastFramePosition).normalized;

        if (moveDirection.y > Mathf.Abs(moveDirection.x))
        {
            if (moveDirection.x > 0)
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
            if (moveDirection.x > 0)
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

    private void LateUpdate()
    {
        lastFramePosition = transform.position;
    }
}
