using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosPantalla : MonoBehaviour {

    public Text nombreJugador;
    public Text nivelJugador;
    
	// Use this for initialization
	void Start () {
        nombreJugador.text = DatosPartida.GetJugador().GetNombre();
        nivelJugador.text = "Nivel " + DatosPartida.GetJugador().GetNivel().ToString();
    }
	
}
