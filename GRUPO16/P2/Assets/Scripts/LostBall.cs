using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform respawn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//cacheo de componentes
    }

    //método al que se llama cuando la bola se destruye
    public void OnLost()
    {
        //Alive es una variable de método que nos indica si el jugador está vivo.
        //Si la escena no tiene game manager, siempre estará vivo, pero si lo tiene, puede estar vivo o muerto.
        bool alive = true;
        if (GameManager.instance != null) alive = GameManager.instance.PlayerLoseLife();

        if (alive)//en caso de que tenga gameManager Y esté vivo, le hace respawn
        {
            transform.position = respawn.position;
            rb.isKinematic = true;
            transform.SetParent(respawn.parent);
            rb.velocity = new Vector2(0, 0);
        }
        else Destroy(this.gameObject);//en caso contrario, estará muerto así que se destruirá el jugador
    }

}
