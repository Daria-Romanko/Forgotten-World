using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float moveInput;

    private Rigidbody2D rigidbody;
    private bool fasingRight;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);
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
