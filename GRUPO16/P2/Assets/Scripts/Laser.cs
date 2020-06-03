using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject fire;//objeto a instanciar
    public Sprite vausLaserPower;
    Sprite originalSprite;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();//cacheo de componentes
        originalSprite = spriteRenderer.sprite;//guardamos el sprite del objeto
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))//si se pulsa la barra espaciadora, isntanciará una bala
        {
            Instantiate<GameObject>(fire, transform.position, Quaternion.identity);
        }        
    }
    private void OnEnable()
    {
        spriteRenderer.sprite = vausLaserPower;
    }
    private void OnDisable()
    {
        spriteRenderer.sprite = originalSprite;
    }
}
