using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    private Vector3 comienzoPaneo;
    public Camera camara;
    private int alturaSuelo = 0;
    void Start()
    {
        if (camara == null) camara = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) comienzoPaneo = GetWorldPosition(alturaSuelo);
        if (Input.GetMouseButton(0))
        {
            Vector3 direccion = comienzoPaneo - GetWorldPosition(alturaSuelo);
            camara.transform.position += direccion;
        }
    }
    private Vector3 GetWorldPosition(float y)
    {
        Ray posicionMouse = camara.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0,y,0));
        float distancia;
        ground.Raycast(posicionMouse, out distancia);
        return posicionMouse.GetPoint(distancia);
    }
}
