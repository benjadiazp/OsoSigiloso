using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ColoresRandom : MonoBehaviour
{
    public float opacidad = 0.5f;
    Image imagen;
    float cont;
    Color colorObjetivo;
    void Start()
    {
        cont = 0f;
        colorObjetivo = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), opacidad);
        if (imagen == null) imagen = GetComponent<Image>();
    }
    void Update()
    {
        if (cont >= 3)
        {
            colorObjetivo = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), opacidad);
            cont = 0;
        }
        cont += Time.deltaTime;
        imagen.color = Color.Lerp(imagen.color, colorObjetivo, Time.deltaTime);
    }
}
