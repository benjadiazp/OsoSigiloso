using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOso : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadGiro = 100f;

    private Transform camara;
    private Animator anim;
    private Rigidbody rb;
    private CamaraPrincipal posCamara;
    //Variables para celular.
    private bool tocando;
    Vector2 posInicio;
    Vector2 posFinal;
    Vector2 desplazamientoSwipe;

    public RectTransform circuloInterior;
    public RectTransform circuloExterior;
    private void Start() //Aquí se obtienen los componentes que se usarán más adelante, en Update.
    {
        tocando = false;
        posInicio = new Vector2();
        posFinal = new Vector2();
        desplazamientoSwipe = new Vector2();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        camara = Camera.main.transform;
        posCamara = Camera.main.GetComponent<CamaraPrincipal>();
        if (circuloExterior == null) circuloExterior = GameObject.FindGameObjectWithTag("joystick2").GetComponent<RectTransform>();
        if (circuloInterior == null) circuloInterior = GameObject.FindGameObjectWithTag("joystick1").GetComponent<RectTransform>();
        circuloExterior.gameObject.SetActive(false);
        circuloInterior.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            if (toque.phase == TouchPhase.Began)
            {
                posInicio = new Vector2(toque.position.x, toque.position.y);
                circuloExterior.gameObject.SetActive(true);
                circuloInterior.gameObject.SetActive(true);
                circuloInterior.transform.position = posInicio;
                circuloExterior.transform.position = posInicio;
            }
            else if (toque.phase == TouchPhase.Moved)
            {
                posFinal = new Vector2(toque.position.x, toque.position.y);
                Vector2 desplazamiento = Vector2.ClampMagnitude((posFinal - posInicio), 100f);
                circuloInterior.transform.position = posInicio + desplazamiento;
                desplazamientoSwipe = Vector2.ClampMagnitude(desplazamiento/100f, 1f)*-1;
            }
            else if (toque.phase == TouchPhase.Ended)
            {
                circuloExterior.gameObject.SetActive(false);
                circuloInterior.gameObject.SetActive(false);
                desplazamientoSwipe = new Vector2();
            }
        }
        else
        {
            posInicio = new Vector2();
            posFinal = new Vector2();
        }
    }
    private void FixedUpdate()
        /* 
         * Este script está asociado a un Rigidbody.
         * Se recomienda usar FixedUpdate en lugar de Update cuando se utiliza el motor de físicas dentro del script.
         */
    {
        Vector3 direccion = camara.right * Input.GetAxis("Horizontal") + camara.forward * Input.GetAxis("Vertical") + new Vector3(desplazamientoSwipe.x, 0f, desplazamientoSwipe.y);
        direccion.y = 0;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || (desplazamientoSwipe.magnitude > 0))
        {
            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direccion), velocidadGiro * Time.deltaTime);
            rb.velocity = transform.forward * velocidad;
            anim.SetFloat("velocidad", 1);
            if (Input.GetAxis("Vertical") <= 0) posCamara.ajustarDistancia();
            else posCamara.resetearDistancia();
        }
        else
        {
            posCamara.resetearDistancia();
            anim.SetFloat("velocidad", 0);
        }
    }
}
