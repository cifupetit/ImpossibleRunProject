using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarksController : MonoBehaviour {

    public GameObject car;
    public GameObject lastMarker;
    public GameObject theMarker;
    public GameObject mark01;
    public GameObject mark02;
    public GameObject mark03;
    public GameObject mark04;
    public GameObject mark05;
    public GameObject mark06;
    public GameObject mark07;
    public GameObject mark08;
    public GameObject mark09;
    public GameObject mark10;
    public GameObject mark11;
    public GameObject mark12;
    public GameObject mark13;
    public GameObject mark14;
    public GameObject mark15;
    public GameObject mark16;
    public GameObject mark17;
    public GameObject mark18;
    public GameObject mark19;
    public GameObject mark20;
    public GameObject mark21;
    public GameObject mark22;
    public GameObject mark23;
    private int markTracker;
    public CuentaAtras cuentaAtras;

    public Text nivelJugador;

    // Use this for initialization
    void Start () {
        lastMarker.transform.position = car.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        switch (markTracker)
        {
            case 0:
                lastMarker.transform.position = mark23.transform.position;
                theMarker.transform.position = mark01.transform.position;
                break;

            case 1:
                lastMarker.transform.position = mark01.transform.position;
                theMarker.transform.position = mark02.transform.position;
                break;

            case 2:
                lastMarker.transform.position = mark02.transform.position;
                theMarker.transform.position = mark03.transform.position;
                break;

            case 3:
                lastMarker.transform.position = mark03.transform.position;
                theMarker.transform.position = mark04.transform.position;
                break;

            case 4:
                lastMarker.transform.position = mark04.transform.position;
                theMarker.transform.position = mark05.transform.position;
                break;

            case 5:
                lastMarker.transform.position = mark05.transform.position;
                theMarker.transform.position = mark06.transform.position;
                break;

            case 6:
                lastMarker.transform.position = mark06.transform.position;
                theMarker.transform.position = mark07.transform.position;
                break;

            case 7:
                lastMarker.transform.position = mark07.transform.position;
                theMarker.transform.position = mark08.transform.position;
                break;

            case 8:
                lastMarker.transform.position = mark08.transform.position;
                theMarker.transform.position = mark09.transform.position;
                break;

            case 9:
                lastMarker.transform.position = mark09.transform.position;
                theMarker.transform.position = mark10.transform.position;
                break;

            case 10:
                lastMarker.transform.position = mark10.transform.position;
                theMarker.transform.position = mark11.transform.position;
                break;

            case 11:
                lastMarker.transform.position = mark11.transform.position;
                theMarker.transform.position = mark12.transform.position;
                break;

            case 12:
                lastMarker.transform.position = mark12.transform.position;
                theMarker.transform.position = mark13.transform.position;
                break;

            case 13:
                lastMarker.transform.position = mark13.transform.position;
                theMarker.transform.position = mark14.transform.position;
                break;

            case 14:
                lastMarker.transform.position = mark14.transform.position;
                theMarker.transform.position = mark15.transform.position;
                break;

            case 15:
                lastMarker.transform.position = mark15.transform.position;
                theMarker.transform.position = mark16.transform.position;
                break;

            case 16:
                lastMarker.transform.position = mark16.transform.position;
                theMarker.transform.position = mark17.transform.position;
                break;

            case 17:
                //lastMarker.transform.position = mark17.transform.position;
                theMarker.transform.position = mark18.transform.position;
                break;

            case 18:
                //lastMarker.transform.position = mark18.transform.position;
                theMarker.transform.position = mark19.transform.position;
                break;

            case 19:
                lastMarker.transform.position = mark19.transform.position;
                theMarker.transform.position = mark20.transform.position;
                break;

            case 20:
                lastMarker.transform.position = mark20.transform.position;
                theMarker.transform.position = mark21.transform.position;
                break;

            case 21:
                lastMarker.transform.position = mark21.transform.position;
                theMarker.transform.position = mark22.transform.position;
                break;

            case 22:
                lastMarker.transform.position = mark22.transform.position;
                theMarker.transform.position = mark23.transform.position;
                break;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SkyCar")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Light>().enabled = false;
            markTracker++;
            cuentaAtras.sumaTiempo();
            if (markTracker == 23)
            {
                markTracker = 0;
                DatosPartida.GetJugador().SetNivel(DatosPartida.GetJugador().GetNivel() + 1);
                nivelJugador.text = "Nivel " + DatosPartida.GetJugador().GetNivel().ToString();
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<Light>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
