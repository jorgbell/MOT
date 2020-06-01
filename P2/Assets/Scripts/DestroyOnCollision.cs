using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int golpesAntesDeMorir, puntosGanados;
    int golpesRecibidos;
    public GameObject dieObject;
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
            if(dieObject!=null) Instantiate<GameObject>(dieObject, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
