using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class CargaGuardado {

    public const string PATHARCHIVO = "/partidaGuardada.gd";

    public static void Guarda()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + PATHARCHIVO);
        bf.Serialize(fs, DatosPartida.GetJugador());
        fs.Close();
    }

    public static void Carga()
    {
        if (File.Exists(Application.persistentDataPath + PATHARCHIVO))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + PATHARCHIVO, FileMode.Open);
            DatosPartida.CargaDatos((Jugador)bf.Deserialize(fs));
            fs.Close();
        }
    }
}
