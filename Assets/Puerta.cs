using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Puerta : MonoBehaviour
{
    private Animator anim;
    int contador;
    void Start()
    {
        contador = 0;
        if (anim==null) anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.gameObject.tag == "Robot")
        {
            contador++;
            anim.SetBool("Abrir", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Robot")
        {
            contador--;
            if (contador == 0) anim.SetBool("Abrir", false);
        }
    }
}
