using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public static class DatosPartida {//: MonoBehaviour{

    //public static DatosPartida partida;
    private static string nombreJ;
    private static int nivel;
    private static string[] resultado = { nombreJ, nivel.ToString() };

    /*void Awake()
    {
        if (partida == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (partida != this)
        {
            Destroy(gameObject);
        }
    }

    public DatosPartida ()
    {
        //partida = new DatosPartida();
        partida.nombreJ = "";
        partida.nivel = 1;
    }

    public DatosPartida (string nombre, int nivel)
    {
        //partida = new DatosPartida();
        partida.nombreJ = nombre;
        partida.nivel = nivel;
        Debug.Log(partida.nombreJ + "    " + partida.nivel);
    }*/

    public static void SetNombreJPartida(string nombre)
    {
        nombreJ = nombre;
        resultado[0] = nombre;

        //textoNombre = GameObject.Find("NombreJugador").GetComponent<Text>();

        //textoNombre.text = nombre;
    }

    public static string GetNombreJPartida()
    {
        return nombreJ;
    }

    public static void SetNivelPartida(int nivel)
    {
        nivel = nivel;
        resultado[1] = nivel.ToString();
    }

    public static int GetNivelPartida()
    {
        return nivel;
    }

    public static void ActualizaDatos()
    {
        nombreJ = resultado[0];
        nivel = int.Parse(resultado[1]);
    }

    public static void CargaDatos(string[] datos)
    {
        DatosPartida.SetNombreJPartida(datos[0]);
        DatosPartida.SetNivelPartida(int.Parse(datos[1]));
    }

    public static string[] GetResultado()
    {
        return resultado;
    }
}
