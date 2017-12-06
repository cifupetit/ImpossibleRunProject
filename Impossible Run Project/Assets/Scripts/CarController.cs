using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public WheelCollider ruedaDelDer;
    public WheelCollider ruedaDelIzq;
    public WheelCollider ruedaTraDer;
    public WheelCollider ruedaTraIzq;

    public float giroRuedas;
    public float maxGiroRuedas;

    public float fuerzaMotor;
    public float maxFuerzaMotor;

    public float freno;
    public bool estoyFrenando;

    public Vector3 posCentroDeMasas;    //posición del centro de masas del vehículo
    public Vector3 posicionRueda;   //tanto posición como rotación servirán para posicionar el
    public Quaternion rotacionRueda;//GameObject que posee el WheelCollider en el centro del modelo de rueda

	// Use this for initialization
	void Start () {
        this.giroRuedas = 0.0f;
        this.maxGiroRuedas = 25.0f;
        this.fuerzaMotor = 0.0f;
        this.maxFuerzaMotor = 800.0f;
        this.estoyFrenando = false;
        this.posCentroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
