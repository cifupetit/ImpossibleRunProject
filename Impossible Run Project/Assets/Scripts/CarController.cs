﻿using System.Collections;
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
        giroRuedas = 0.0f;
        maxGiroRuedas = 25.0f;
        fuerzaMotor = 0.0f;
        maxFuerzaMotor = 800.0f;
        estoyFrenando = false;
        posCentroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);

        this.gameObject.GetComponent<Rigidbody>().centerOfMass = posCentroDeMasas; // le asignamos el centro de masas al vehículo
	}
	
	// Update is called once per frame
	void Update () {
        fuerzaMotor = maxFuerzaMotor * Input.GetAxis("Vertical");
        giroRuedas = maxGiroRuedas * Input.GetAxis("Horizontal");
        
        if (Input.GetButton("Jump"))
        {
            estoyFrenando = true;
        }
        else
        {
            estoyFrenando = false;
        }

        //asignamos el giro a las ruedas delanteras
        ruedaDelDer.steerAngle = giroRuedas;
        ruedaDelIzq.steerAngle = giroRuedas;

        //asignamos la fuerza del motor a las ruedas, en nuestro caso, solo traseras
        ruedaDelDer.motorTorque = fuerzaMotor;
        ruedaDelIzq.motorTorque = fuerzaMotor;
        ruedaTraDer.motorTorque = fuerzaMotor;
        ruedaTraIzq.motorTorque = fuerzaMotor;

        //fuerza de frenado
        if (estoyFrenando)
        {
            ruedaDelDer.brakeTorque = 400.0f;
            ruedaDelIzq.brakeTorque = 400.0f;
            ruedaTraDer.brakeTorque = 400.0f;
            ruedaTraIzq.brakeTorque = 400.0f;
        }
        else
        {
            ruedaDelDer.brakeTorque = 0.0f;
            ruedaDelIzq.brakeTorque = 0.0f;
            ruedaTraDer.brakeTorque = 0.0f;
            ruedaTraIzq.brakeTorque = 0.0f;
        }

        //asignar centros de las ruedas con los centros de sus modelos, posicion y rotacion
        Transform ruedaDD = ruedaDelDer.gameObject.transform.GetChild(0);
        ruedaDelDer.GetComponent<WheelCollider>().GetWorldPose(out posicionRueda, out rotacionRueda);
        ruedaDD.transform.position = posicionRueda;
        ruedaDD.transform.rotation = rotacionRueda;

        Transform ruedaDI = ruedaDelIzq.gameObject.transform.GetChild(0);
        ruedaDelIzq.GetComponent<WheelCollider>().GetWorldPose(out posicionRueda, out rotacionRueda);
        ruedaDI.transform.position = posicionRueda;
        ruedaDI.transform.rotation = rotacionRueda;

        Transform ruedaTD = ruedaTraDer.gameObject.transform.GetChild(0);
        ruedaTraDer.GetComponent<WheelCollider>().GetWorldPose(out posicionRueda, out rotacionRueda);
        ruedaTD.transform.position = posicionRueda;
        ruedaTD.transform.rotation = rotacionRueda;

        Transform ruedaTI = ruedaTraIzq.gameObject.transform.GetChild(0);
        ruedaTraIzq.GetComponent<WheelCollider>().GetWorldPose(out posicionRueda, out rotacionRueda);
        ruedaTI.transform.position = posicionRueda;
        ruedaTI.transform.rotation = rotacionRueda;
    }
}
