using System.Collections;
using UnityEngine;

[System.Serializable]
public class DatosPartida {

    public static DatosPartida partida;
    public string nombreJ;
    public int nivel;

    public DatosPartida ()
    {
        nombreJ = "";
        nivel = 0;
    }

}
