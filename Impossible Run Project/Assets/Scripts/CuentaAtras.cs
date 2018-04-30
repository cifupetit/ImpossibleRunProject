using UnityEngine;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour {

    public Text textoDerrota;
    public Text cronometro;

    private static float tiempo;
    private bool debeDisminuir;

    public Button pausa;

    // Use this for initialization
    void Start()
    {
        textoDerrota.enabled = false;
        switch (DatosPartida.GetNivelPartida())
        {
            case 1:
                tiempo = 40.0f;
                break;

            case 2:
                tiempo += 30.0f;
                break;

            case 3:
                tiempo += 20.0f;
                break;

            case 4:
                tiempo += 15.0f;
                break;

            case 5:
                tiempo += 10.0f;
                break;

            case 6:
                tiempo += 8.0f;
                break;

            case 7:
                tiempo += 6.0f;
                break;

            default:
                tiempo += 5.0f;
                break;
        }
        
        debeDisminuir = true;
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

    public void sumaTiempo()
    {
        switch (DatosPartida.GetNivelPartida())
        {
            case 1:
                tiempo += 10.0f;
                break;

            case 2:
                tiempo += 8.0f;
                break;

            case 3:
                tiempo += 6.0f;
                break;

            case 4:
                tiempo += 5.0f;
                break;

            case 5:
                tiempo += 4.0f;
                break;

            case 6:
                tiempo += 4.0f;
                break;

            case 7:
                tiempo += 3.0f;
                break;

            case 8:
                tiempo += 3.0f;
                break;

            case 9:
                tiempo += 2.0f;
                break;

            case 10:
                tiempo += 2.0f;
                break;

            default:
                tiempo += 1.5f;
                break;
        }
    }
    
    public static float getTiempo()
    {
        return tiempo;
    }
}
