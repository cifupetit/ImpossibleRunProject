using UnityEngine;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour {

    public Text cronometro;

    private float tiempo;
    private bool debeDisminuir;

    private Button pausa;

    //public int cuentaAtras;
    //public bool auxCuentaAtras;

    // Use this for initialization
    void Start()
    {
        tiempo = 20.0f;
        debeDisminuir = true;
        pausa = GameObject.Find("Button_Reanudar").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update () {
        cronometro.text = "Tiempo:" + " " + tiempo.ToString("f0");

        if (debeDisminuir)
        {
            tiempo -= Time.deltaTime;

            if (tiempo <= 0.0f)  // Comprueba si es menor o igual a cero.
            {
                debeDisminuir = false; // Deja de descontar y activa el menu de pausa.
                pausa.onClick.Invoke();
                pausa.enabled = false;
            }
        }

        if (tiempo <= 0.0f)
            {
                cronometro.color = Color.red; // Comprueba para cambiar el color del text. 
            }
            else
            {
                cronometro.color = Color.green; // Vuelve a verde cuando aumente...
            }

        }
	
}
