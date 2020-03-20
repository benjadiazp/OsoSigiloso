using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class IARobot : MonoBehaviour
{
    float temporizador;
    public Transform[] waypoints;
    public Transform oso;
    public float tiempoBusqueda = 10f;
    public float distanciaAtaque = 1.5f;
    public float anguloVision = 70f;
    NavMeshAgent nav;
    int waypointActual;
    bool jugadorDetectado;
    CanvasGroup iconoAlerta;
    void Start()
    {
        jugadorDetectado = false;
        temporizador = 0f;
        nav = GetComponent<NavMeshAgent>();
        if (oso == null) oso = GameObject.FindGameObjectWithTag("Player").transform;
        iconoAlerta = GetComponentInChildren<CanvasGroup>();
        ControlNivel.instancia.OnJugadorDetectadoPorRadar += EstadoAlerta;
    }

    
    void Update()
    {
        if (jugadorDetectado) //Esta función retorna true cuando un robot detecta al jugador.
        {
            temporizador = tiempoBusqueda; //Se restablece a diez el tiempo de búsqueda.
            perseguirJugador(); //El robot persigue al jugador.
        }
        else if (temporizador > 0) //El robot busca al jugador hasta que la cuenta atrás llegue a cero.
        {
            temporizador -= Time.deltaTime; //Se restan los segundos del temporizador.
            buscarJugador(); //El robot comienza un proceso de búsqueda.
        }
        else
        {
            patrullar(); //Cuando ya han pasado los 10 segundos, el robot sigue patrullando.
        }
    }

    private void FixedUpdate()
    {

        Vector3 adelante = transform.TransformDirection(Vector3.forward);
        Vector3 dirJugador = oso.position - transform.position;
        float angulo = Vector3.Angle(adelante, dirJugador);
        if ((angulo < anguloVision || angulo > 360 - anguloVision) && Physics.Raycast(transform.position, dirJugador, out RaycastHit hitInfo, 5))
        {
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                Debug.DrawRay(transform.position, dirJugador, Color.green);
                jugadorDetectado = true;
            }
            else jugadorDetectado = false;
        }
        else jugadorDetectado = false;
    }
    void EstadoAlerta()
    {
        jugadorDetectado = true;
    }

    void perseguirJugador()
    {
        iconoAlerta.alpha = 1f;
        nav.SetDestination(oso.position);
        if (Vector3.Distance(oso.position, transform.position) < distanciaAtaque)
        {
            ControlNivel.instancia.ReiniciarNivel();
        }
        
    }

    void buscarJugador()
    {
        iconoAlerta.alpha = 0.5f;
        nav.SetDestination(oso.position);
    }

    void patrullar()
    {
        iconoAlerta.alpha = 0f;
        if (waypoints == null) return;
        else
        {
            if (Vector3.Distance(waypoints[waypointActual].position, transform.position) < 0.7)
            {
                if (waypointActual < waypoints.Length - 1)
                {
                    waypointActual++;
                }
                else
                {
                    waypointActual = 0;
                }
            }
            nav.SetDestination(waypoints[waypointActual].position);
        }
    }
}
