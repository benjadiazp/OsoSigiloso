
using UnityEngine;
public class ContadorSegundos : MonoBehaviour
{
    float contador;
    int aux;
    void Start()
    {
        contador = 0f;
    }
    void Update()
    {
        contador += Time.deltaTime;
        if ((int)contador > aux)
        {
            aux = (int)contador;
        }
    }
}
