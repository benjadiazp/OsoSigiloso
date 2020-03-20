using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SeguirObjetivo : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent nav;
    private void Start() //Condiciones iniciales
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update() //Método llamado por cada fotograma.
    {
        if (objetivo != null)
        {
            Seguir(objetivo);
        }
    }
    void Seguir(Transform objetivo)
    {
        nav.SetDestination(objetivo.position);
    }
}
