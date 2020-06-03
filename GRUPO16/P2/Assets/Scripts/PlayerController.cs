using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;
    float input;
    float width;
    Rigidbody2D rb;
    Collider2D col;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//cacheo de componentes
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");//leemos el input
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input * velocityScale, 0);//cambiamos la velocidad en función de si hay o no input
        rb.velocity.Normalize();
    }

    //método que redirige la bola cuando rebota con el jugador, calculando la dirección a la que debe ir
    public float HitFactor(Vector2 ballPos)
    {
        width = col.bounds.extents.x;//leemos la anchura en cada rebote debido a que según el tamaño de la pala, será un hitfactor diferente
        return (ballPos.x - transform.position.x) / width;
    }
}
