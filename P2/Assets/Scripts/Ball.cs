using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    bool input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetButton("Submit");
    }

    private void FixedUpdate()
    { 
        if (rb.isKinematic == true)
        {
            if (input)
            {
                float random = Random.Range(-1.0f, 1.0f);
                Vector2 dir = new Vector2(random, 1f);     
                dir.Normalize();
                rb.velocity = dir *speed;
                rb.isKinematic = false;
                transform.SetParent(null);
            }       
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            float hitFactor = player.HitFactor(transform.position);
            Vector2 factorDir = new Vector2(hitFactor, 1);
            factorDir.Normalize();
            rb.velocity = factorDir * speed;
        }

    }
}
