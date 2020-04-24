using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;
    Rigidbody2D rb;
    float input;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(input * velocityScale, 0);
        rb.velocity.Normalize();
    }
}
