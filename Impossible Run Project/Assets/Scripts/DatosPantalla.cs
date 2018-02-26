using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosPantalla : MonoBehaviour {

    public Text nombreJugador;
    
	// Use this for initialization
	void Start () {
		//nombreJugador = GameObject.Find("NombreJugador").GetComponent<Text>();
        nombreJugador.text = DatosPartida.GetNombreJPartida();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
