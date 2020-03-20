using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public Transicion transicion;
    private void Start()
    {
        if (!transicion) transicion = GameObject.FindGameObjectWithTag("Transicion").GetComponent<Transicion>();
    }
    private void OnTriggerEnter(Collider other)
    {
        transicion.ActivarTransicion();
    }
}
