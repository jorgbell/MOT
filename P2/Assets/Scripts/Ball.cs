using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 dir;
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
                dir = new Vector2(random, 1f);     
                dir.Normalize();
                rb.velocity = dir *speed;
                rb.isKinematic = false;
                transform.SetParent(null);
            }       
        }

    }

}
