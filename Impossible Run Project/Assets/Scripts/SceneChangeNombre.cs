using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeNombre : MonoBehaviour {
    public GameObject inputFieldNombre;

    public void CargaEscenaNombre(string nombreEscena)
    {
        InputField inputFiled = inputFieldNombre.GetComponent<InputField>();
        //Debug.Log(inputFiled.text);
        DatosPartida.SetNombreJPartida(inputFiled.text);
        DatosPartida.SetNivelPartida("1");

        SceneManager.LoadScene(nombreEscena);
    }
}
