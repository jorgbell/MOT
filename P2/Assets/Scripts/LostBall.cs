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
        if (GameManager.instance.PlayerLoseLife())
        {
            transform.position = respawn.position;
            rb.isKinematic = true;
            transform.SetParent(respawn.parent);
            rb.velocity = new Vector2(0, 0);
        }
        else Destroy(this.gameObject);
    }
}
