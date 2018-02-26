using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaCierra : MonoBehaviour {

	public void GuardaDatosCierraApp ()
    {
        CargaGuardado.Guarda();
        Application.Quit();
    }
}
