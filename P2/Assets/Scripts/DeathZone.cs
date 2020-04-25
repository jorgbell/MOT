using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LostBall ball = collision.gameObject.GetComponent<LostBall>();
        if (ball != null)
            ball.OnLost();
        else
            Destroy(collision.gameObject);
    }
}
