using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;

    public float speed;
    public float jumpForce;
    bool jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(horizontal) > 0)
        {
            rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
        }
        else rb.velocity = new Vector2(0,rb.velocity.y);

        if (jump)
        {
            jump = false;
            Vector2 force = new Vector2(0, jumpForce);
            rb.AddForce(force, ForceMode2D.Impulse);
            
        }
    }
}
