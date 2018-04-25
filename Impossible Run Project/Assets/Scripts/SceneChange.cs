using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour {

    public void CargaEscena (string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void CargaDatosCargaEscena(string nombreEscena)
    {
        if (DatosPartida.GetNombreJPartida() == null) //para no machacar los datos del jugador si estos ya estan cargados y se vuelve a pasar por el menu principal
        {
            CargaGuardado.Carga();
        }
        SceneManager.LoadScene(nombreEscena);
    }
}
