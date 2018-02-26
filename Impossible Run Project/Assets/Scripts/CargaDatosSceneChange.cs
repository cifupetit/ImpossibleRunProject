using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaDatosSceneChange : MonoBehaviour {

	public void CargaDatosCargaEscena (string nombreEscena)
    {
        if (DatosPartida.GetNombreJPartida() == null)
        {
            CargaGuardado.Carga();
        }
        SceneManager.LoadScene(nombreEscena);
    }
}
