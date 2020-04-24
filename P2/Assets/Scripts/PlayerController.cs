using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;
    Rigidbody2D rb;
    float input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = 0;
    }

    // Update is called once per frame
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
