using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int golpesAntesDeMorir, puntosGanados;//variables de control
    int golpesRecibidos;
    public GameObject dieObject;
    // Start is called before the first frame update
    void Start()
    {
        golpesRecibidos = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        golpesRecibidos++;//si colisiona, sumamos 1 y comprobamos que llegue al tope o no
        if (golpesRecibidos == golpesAntesDeMorir)//si llega al tope de golpes
        {
            if(GameManager.instance!=null)GameManager.instance.AddPoints(puntosGanados); //suma puntos
            if(dieObject!=null) Instantiate<GameObject>(dieObject, transform.position, Quaternion.identity);//spawnea un objeto
            Destroy(this.gameObject);//destruye el objeto
        }
    }
}
