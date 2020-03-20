using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Musica : MonoBehaviour
{
    public static Musica instancia;
    AudioSource musica;
    void Start()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instancia = this;
        }
        musica = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
}
