using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class MostrarNombreNivel : MonoBehaviour
{
    TextMeshProUGUI texto;
    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        texto.text = ControladorEscenas.getEscenaActual();
    }
}
