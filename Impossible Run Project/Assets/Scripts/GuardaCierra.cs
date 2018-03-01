using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaCierra : MonoBehaviour {

	public void GuardaDatosCierraApp ()
    {
        if (DatosPartida.GetNombreJPartida() != null) //para evitar machacar los datos del archivo si no llega a cargar la partida o crear una nueva antes de salir
        {
            CargaGuardado.Guarda();
        }
        Application.Quit();
    }
}
