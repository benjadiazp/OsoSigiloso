using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraVigilancia : MonoBehaviour
{
    public Color normal = Color.green;
    public Color normal2 = Color.cyan;
    public Color alerta = Color.red;
    public Color alerta2 = Color.magenta;
    Renderer renderRadar;
    void Start()
    {
        renderRadar = GetComponent<Renderer>();
        modoNormal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") modoAlerta();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") modoSospecha();
    }

    void modoNormal()
    {
        renderRadar.material.SetColor("Color1", normal);
        renderRadar.material.SetColor("Color2", normal2);
    }

    void modoAlerta()
    {
        ControlNivel.instancia.estadoAlerta();
        renderRadar.material.SetColor("Color1", alerta);
        renderRadar.material.SetColor("Color2", alerta2);
    }

    void modoSospecha()
    {
        renderRadar.material.SetColor("Color1", Color.yellow);
        renderRadar.material.SetColor("Color2", Color.yellow);
    }
}
