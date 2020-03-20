using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorUI : MonoBehaviour
{
    public string nombreNivel;
    void Start()
    {
        if (nombreNivel.Equals("")) nombreNivel = ControladorEscenas.getEscenaActual();
    }
}
