using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float moveInput;

    private Rigidbody2D playerRigidbody;
    private bool fasingRight;

    private bool isPlayerBlocked = false;

    private Animator animator;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    
    private void FixedUpdate()
    {
        if (!isPlayerBlocked)
        {
            moveInput = Input.GetAxis("Horizontal");
            playerRigidbody.velocity = new Vector2(moveInput * speed, playerRigidbody.velocity.y);
            if (fasingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (fasingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (moveInput == 0)
            {
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isRunning", true);
            }
        }
    }


    void Flip()
    {
        fasingRight = !fasingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void BlockPlayerMovement()
    {
        Debug.Log("Player movement blocked");
        isPlayerBlocked = true;
        animator.SetBool("isRunning", false);
    }

    public void UnblockPlayerMovement()
    {
        Debug.Log("Player movement unblocked");
        isPlayerBlocked = false;
    }
}
