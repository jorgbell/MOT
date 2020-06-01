using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;
    Rigidbody2D rb;
    float input;
    Collider2D col;
    float width;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        width = col.bounds.extents.x;
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

    public float HitFactor(Vector2 ballPos)
    {
        width = col.bounds.extents.x;
        return (ballPos.x - transform.position.x) / width;
    }
}
