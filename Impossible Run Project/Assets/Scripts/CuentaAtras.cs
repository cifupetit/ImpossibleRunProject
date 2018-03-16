using UnityEngine;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour {

    public Text textoDerrota;
    public Text cronometro;

    private float tiempo;
    private bool debeDisminuir;

    public Button pausa;

    //public int cuentaAtras;
    //public bool auxCuentaAtras;

    // Use this for initialization
    public void Start()
    {
        int auxNivel = DatosPartida.GetNivelPartida();
        //Debug.Log(auxNivel);
        switch (auxNivel)
        {
            case 1:
                tiempo = 30.0f;
                break;

            case 2:
                tiempo = 20.0f;
                break;

            case 3:
                tiempo = 10.0f;
                break;

            case 4:
                tiempo = 5.0f;
                break;
        }
        //tiempo = 20.0f;

        debeDisminuir = true;
        //pausa = GameObject.Find("Button_Reanudar").GetComponent<Button>();
        textoDerrota.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        cronometro.text = "Tiempo:" + " " + tiempo.ToString("f0");

        if (debeDisminuir)
        {
            tiempo -= Time.deltaTime;

            if (tiempo <= 0.0f)  // Comprueba si es menor o igual a cero.
            {
                debeDisminuir = false; // Deja de descontar, activa el menu de pausa y muestra el texto de derrota.
                pausa.onClick.Invoke();
                pausa.enabled = false;
                textoDerrota.enabled = true;
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
