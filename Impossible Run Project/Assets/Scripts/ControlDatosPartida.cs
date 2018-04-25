using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDatosPartida : MonoBehaviour {

    public Button botonContinuar;

    // Use this for initialization
    void Start()
    {
        if (DatosPartida.GetResultado() == null)
        {
            botonContinuar.enabled = false;
        }
    }

    public void GuardaDatosCierraApp ()
    {
        if (DatosPartida.GetNombreJPartida() != null) //para evitar machacar los datos del archivo si no llega a cargar la partida o crear una nueva antes de salir
        {
            CargaGuardado.Guarda();
        }
        Application.Quit();
    }
}
