using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    public Vector2 initialVelocity;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//cacheo de componentes
        rb.velocity = initialVelocity;//le damos una velocidad constante cuando el componente aparezca
    }
}
