using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Transicion : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ActivarTransicion()
    {
        anim.SetTrigger("TerminarNivel");
    }

    public void AvanzarNivel()
    {
        ControladorEscenas.cargarSiguienteNivel();
    }
}
