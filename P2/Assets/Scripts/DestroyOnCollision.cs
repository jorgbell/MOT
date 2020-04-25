using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int golpesAntesDeMorir, puntosGanados;
    int golpesRecibidos;
    // Start is called before the first frame update
    void Start()
    {
        golpesRecibidos = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        golpesRecibidos++;
        if (golpesRecibidos == golpesAntesDeMorir)
        {
            if(GameManager.instance!=null)GameManager.instance.AddPoints(puntosGanados);
            Destroy(this.gameObject);
        }
    }
}
