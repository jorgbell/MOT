using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform respawn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnLost()
    {
        //Alive es una variable de método que nos indica si el jugador está vivo.
        //Si la escena no tiene game manager, siempre estará vivo, pero si lo tiene, puede estar vivo o muerto.
        bool alive = true;
        if (GameManager.instance != null) alive = GameManager.instance.PlayerLoseLife();

        if (alive)
        {
            transform.position = respawn.position;
            rb.isKinematic = true;
            transform.SetParent(respawn.parent);
            rb.velocity = new Vector2(0, 0);
        }
        else Destroy(this.gameObject);
    }

}
