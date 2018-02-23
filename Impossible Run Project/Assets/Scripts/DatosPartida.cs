using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DatosPartida : MonoBehaviour{

    public static DatosPartida partida = new DatosPartida();
    public string nombreJ;
    public int nivel;

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
    }

    public static void SetNombreJPartida (string nombre)
    {
        partida.nombreJ = nombre;
        Debug.Log(partida.nombreJ + "    " + partida.nivel);
        
        //textoNombre = GameObject.Find("NombreJugador").GetComponent<Text>();
        
        //textoNombre.text = nombre;
    }

    public static string GetNombreJPartida()
    {
        return partida.nombreJ;
    }

    public static void SetNivelPartida (int nivel)
    {
        partida.nivel = nivel;
    }

    public static int GetNivelPartida ()
    {
        return partida.nivel;
    }
}
