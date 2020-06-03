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
        if (rb.isKinematic && input) //si la pelota está en la pala y además recibe input del jugador, realiza el primer lanzamiento
        {
            float random = Random.Range(-1.0f, 1.0f);   //Le damos una posición random en la X para que el primer lanzamiento siempre sea distinto
            Vector2 dir = new Vector2(random, 1f);
            dir.Normalize();
            rb.velocity = dir * speed;
            //damos a la bola la personalidad dinámica y la separamos de la pala
            rb.isKinematic = false; 
            transform.SetParent(null);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>(); //cachea al jugador
        if (player != null)//sólo deberá realizar un rebote diferente si rebota con el jugador
        {
            float hitFactor = player.HitFactor(transform.position);//calcula la nueva dirección de rebote para que vaya hacia donde el jugador está moviéndose
            Vector2 factorDir = new Vector2(hitFactor, 1);
            factorDir.Normalize();
            rb.velocity = factorDir * speed;
        }

    }
}
