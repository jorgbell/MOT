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
        //aumentamos un 25% el tamaño y hacemos los cálculos necesarios para volver a obtener la escala original
        float scale = originalScale.x + (originalScale.x * PORCENTAJE);
        Vector3 newScale = new Vector3(scale, originalScale.y, originalScale.z);
        transform.localScale = newScale;
        newScale.x = 1 / scale;
        for (int i = 0; i < transform.childCount; i++)//ponemos a los hijos en la escala adecuada
            transform.GetChild(i).localScale = newScale;
        

    }
    private void OnDisable()
    {
        //cuando se desactive el componente mediante el manager proporcionado, se deberá reiniciar el tamaño para cuadrarlo con el original
        transform.localScale = originalScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale = originalScale;
        }
    }
}
