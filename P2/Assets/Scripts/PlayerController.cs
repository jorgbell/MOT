using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;
    Rigidbody2D rb;
    bool input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
