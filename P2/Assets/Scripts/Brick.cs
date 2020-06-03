using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance != null) GameManager.instance.AddBrick();
    }
    private void OnDestroy()
    {
        if(GameManager.instance != null) GameManager.instance.BrickDestroyer();
    }
}
