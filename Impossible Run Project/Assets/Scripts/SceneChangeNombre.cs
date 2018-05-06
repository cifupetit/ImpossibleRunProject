using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeNombre : MonoBehaviour {

    public GameObject inputFieldNombre;
    public Button continuar;

    // Update is called once per frame
    void Update()
    {
        if (inputFieldNombre.GetComponent<InputField>().text.Length < 1)
        {
            continuar.enabled = false;
        }
        else
        {
            continuar.enabled = true;
        }
    }

    public void CargaEscenaNombre(string nombreEscena)
    {
        //Debug.Log(inputFieldNombre.GetComponent<InputField>().text);
        DatosPartida.SetJugador(new Jugador(inputFieldNombre.GetComponent<InputField>().text, 1));

        SceneManager.LoadScene(nombreEscena);
    }
}
