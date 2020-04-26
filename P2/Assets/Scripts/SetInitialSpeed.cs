using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    public Vector2 initialVelocity;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
    }
}
