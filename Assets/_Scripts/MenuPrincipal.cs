using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    void Start()
    {
        ControladorEscenas.imprimirEscenas();
    }

    public void BtnComenzar()
    {
        ControladorEscenas.cargarSiguienteNivel();
    }

    public void BtnSalir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Debug.Log("Chauu");
        Application.Quit();
        #endif
    }
}
