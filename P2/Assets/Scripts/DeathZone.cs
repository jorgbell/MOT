using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LostBall ball = collision.gameObject.GetComponent<LostBall>();//cachea que colisione con la bola
        if (ball != null)
            ball.OnLost();//si colisiona con la bola, debe comprobar si puede hacerla reaparecer y hacerlo en caso afirmativo
        else
            Destroy(collision.gameObject);//si es cualquier otro tipo de objeto, simplemente lo destruye
    }
}
