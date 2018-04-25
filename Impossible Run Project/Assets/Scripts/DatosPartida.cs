using System.Collections;
using UnityEngine;

[System.Serializable]
public static class DatosPartida {
    //primera posicion  del array nombre de jugador y segunda nivel
    private static string[] resultado = new string[2];

    public static void SetNombreJPartida(string nombre)
    {
        resultado[0] = nombre;
    }

    public static string GetNombreJPartida()
    {
        return resultado[0];
    }

    public static void SetNivelPartida(string auxNivel)
    {
        resultado[1] = auxNivel;
    }

    public static string GetNivelPartida()
    {
        return resultado[1];
    }

    public static void CargaDatos(string[] datos)
    {
        DatosPartida.SetNombreJPartida(datos[0]);
        DatosPartida.SetNivelPartida(datos[1]);
    }

    public static string[] GetResultado()
    {
        return resultado;
    }
}
