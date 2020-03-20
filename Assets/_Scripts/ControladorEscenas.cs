using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscenas
{
    public static void imprimirEscenas()
    {
        for (int i=0; i<SceneManager.sceneCountInBuildSettings; i++)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(i).name);
        }
    }
    public static void cargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public static void cargarNivel(int num)
    {
        SceneManager.LoadScene("Nivel_" + num);
    }

    public static void cargarSiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        if (escenaActual < SceneManager.sceneCountInBuildSettings - 1) SceneManager.LoadScene(escenaActual + 1);
        else SceneManager.LoadScene(0);
    }

    public static void reiniciarNivel()
    {
        SceneManager.LoadScene(getEscenaActual());
    }
    public static string getEscenaActual()
    {
        return SceneManager.GetActiveScene().name;
    }
}
