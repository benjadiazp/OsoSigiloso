using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrincipal : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 0.2f;
    public Vector3 separacion = new Vector3(5, 5, 5);
    public float distancia = 1f;
    private Vector3 separacionInicial;
    private void Start()
    {
        if (objetivo == null) objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        separacionInicial = separacion;
    }
    private void FixedUpdate()
    {
        Vector3 proximaPosicion = objetivo.position + separacion;
        Vector3 posicionActual = Vector3.Lerp(transform.position, proximaPosicion, suavizado);
        transform.position = posicionActual;
        transform.LookAt(objetivo);
    }

    public void ajustarDistancia()
    {
        separacion = separacionInicial + new Vector3(distancia, distancia, distancia);
    }

    public void resetearDistancia()
    {
        separacion = separacionInicial;
    }


}
