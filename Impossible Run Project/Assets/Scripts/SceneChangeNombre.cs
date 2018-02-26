using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeNombre : MonoBehaviour {
    public GameObject inputFieldNombre;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void CargaEscenaNombre(string nombreEscena)
    {
        InputField inputFiled = inputFieldNombre.GetComponent<InputField>();
        //Debug.Log(inputFiled.text);
        DatosPartida.SetNombreJPartida(inputFiled.text);
        DatosPartida.SetNivelPartida(1);
        //DatosPartida.partida = new DatosPartida(inputFiled.text, 1);
        //DatosPartida.nombreJ = inputFiled.text;
        //DatosPartida.partida.nivel = 1;

        SceneManager.LoadScene(nombreEscena);
    }
}
