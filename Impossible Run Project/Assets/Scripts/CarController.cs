using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public float fuerzaFrenado;
    public bool estoyFrenando;
    public float fuerzaDerrape;
    public bool estoyDerrapando;

    public Vector3 posCentroDeMasas;    //posición del centro de masas del vehículo
    public Vector3 posicionRueda;   //tanto posición como rotación servirán para posicionar el
    public Quaternion rotacionRueda;//GameObject que posee el WheelCollider en el centro del modelo de rueda

	// Use this for initialization
	void Start () {
        giroRuedas = 0.0f;
        maxGiroRuedas = 25.0f;
        fuerzaMotor = 0.0f;
        maxFuerzaMotor = 1800.0f;
        fuerzaFrenado = 2000.0f;
        estoyFrenando = false;
        fuerzaDerrape = 1000.0f;
        estoyDerrapando = false;

        posCentroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);

        this.gameObject.GetComponent<Rigidbody>().centerOfMass = posCentroDeMasas; // le asignamos el centro de masas al vehículo
	}
	
	// Update is called once per frame
	void Update () {
        fuerzaMotor = maxFuerzaMotor * Input.GetAxis("Vertical");
        giroRuedas = maxGiroRuedas * Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            estoyFrenando = true;
        }
        else
        {
            estoyFrenando = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            estoyDerrapando = true;
        }
        else
        {
            estoyDerrapando = false;
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
            ruedaDelDer.brakeTorque = fuerzaFrenado;
            ruedaDelIzq.brakeTorque = fuerzaFrenado;
            ruedaTraDer.brakeTorque = fuerzaFrenado;
            ruedaTraIzq.brakeTorque = fuerzaFrenado;
        }
        else
        {
            ruedaDelDer.brakeTorque = 0.0f;
            ruedaDelIzq.brakeTorque = 0.0f;
            ruedaTraDer.brakeTorque = 0.0f;
            ruedaTraIzq.brakeTorque = 0.0f;
        }

        if (estoyDerrapando)
        {
            ruedaTraDer.brakeTorque = fuerzaDerrape;
            ruedaTraIzq.brakeTorque = fuerzaDerrape;
            SetFriccionDerrape(1.32f, 0.522f);
        }
        else
        {
            ruedaTraDer.brakeTorque = 0.0f;
            ruedaTraIzq.brakeTorque = 0.0f;
            SetFriccionDerrape(0.82f, 0.022f);
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

    void SetFriccionDerrape (float friccionHaciaDelante, float friccionLateral) //de esta manera ya que no nos deja modificar directente los valores de friccion de los wheelcolliders
    {
        WheelFrictionCurve frictionCurveTraDer1;
        frictionCurveTraDer1 = ruedaTraDer.forwardFriction;
        frictionCurveTraDer1.extremumSlip = friccionHaciaDelante;
        ruedaTraDer.forwardFriction = frictionCurveTraDer1;
        WheelFrictionCurve frictionCurveTraDer2;
        frictionCurveTraDer2 = ruedaTraDer.sidewaysFriction;
        frictionCurveTraDer2.extremumSlip = friccionLateral;
        ruedaTraDer.sidewaysFriction = frictionCurveTraDer2;

        WheelFrictionCurve frictionCurveTraIzq1;
        frictionCurveTraIzq1 = ruedaTraIzq.forwardFriction;
        frictionCurveTraIzq1.extremumSlip = friccionHaciaDelante;
        ruedaTraIzq.forwardFriction = frictionCurveTraIzq1;
        WheelFrictionCurve frictionCurveTraIzq2;
        frictionCurveTraIzq2 = ruedaTraIzq.sidewaysFriction;
        frictionCurveTraIzq2.extremumSlip = friccionLateral;
        ruedaTraIzq.sidewaysFriction = frictionCurveTraIzq2;
        

        /*WheelFrictionCurve frictionCurveDelDer;
        frictionCurveDelDer = ruedaDelDer.sidewaysFriction;
        frictionCurveDelDer.extremumSlip = friccion;
        ruedaDelDer.sidewaysFriction = frictionCurveDelDer;

        WheelFrictionCurve frictionCurveDelIzq;
        frictionCurveDelIzq = ruedaDelIzq.sidewaysFriction;
        frictionCurveDelIzq.extremumSlip = friccion;
        ruedaDelIzq.sidewaysFriction = frictionCurveDelIzq;*/

        /*ruedaTraDer.forwardFriction.stiffness = friccionHaciaDelante;
        ruedaTraIzq.forwardFriction.stiffness = friccionHaciaDelante;
        ruedaDelDer.forwardFriction.stiffness = friccionHaciaDelante;
        ruedaDelIzq.forwardFriction.stiffness = friccionHaciaDelante;

        ruedaTraDer.sidewaysFriction.stiffness = friccionLateral;
        ruedaTraIzq.sidewaysFriction.stiffness = friccionLateral;
        ruedaDelDer.sidewaysFriction.stiffness = friccionLateral;
        ruedaDelIzq.sidewaysFriction.stiffness = friccionLateral;*/
    }
}
