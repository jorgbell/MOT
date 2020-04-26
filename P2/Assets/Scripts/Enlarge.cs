using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    Vector3 originalScale;
    const float PORCENTAJE = 0.25f;

    private void Awake()
    {
        originalScale = transform.localScale;
    }
    private void OnEnable()
    {   
        float scale = originalScale.x + (originalScale.x * PORCENTAJE);
        Vector3 newScale = new Vector3(scale, originalScale.y, originalScale.z);
        transform.localScale = newScale;
        newScale.x = 1 / scale;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale = newScale;
        }

    }
    private void OnDisable()
    {
        transform.localScale = originalScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale = originalScale;
        }
    }
}
