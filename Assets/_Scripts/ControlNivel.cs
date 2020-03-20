using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class ControlNivel : MonoBehaviour
{
    public static ControlNivel instancia;
    public Animator gameOverAnim;
    //Eventos
    public event Action OnJugadorDetectadoPorRadar;

    private void Awake()
    {
        if (instancia == null) instancia = this;
    }
    private void Start()
    {
        if (gameOverAnim == null)
        gameOverAnim = GameObject.FindGameObjectWithTag("PantallaGameOver").GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void estadoAlerta()
    {
        OnJugadorDetectadoPorRadar?.Invoke();
    }
    public void ReiniciarNivel()
    {
        gameOverAnim.SetTrigger("TerminarNivel");
    }

    
}
