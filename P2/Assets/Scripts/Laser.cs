using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject fire;
    public Sprite vausLaserPower;
    Sprite originalSprite;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
