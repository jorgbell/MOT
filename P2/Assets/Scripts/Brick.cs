using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddBrick();
    }
    private void OnDestroy()
    {
        GameManager.instance.BrickDestroyer();
    }
}
