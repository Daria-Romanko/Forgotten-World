using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float moveInput;

    private Rigidbody2D playerRigidbody;
    private bool fasingRight;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
    }

    void Flip()
    {
        fasingRight = !fasingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
