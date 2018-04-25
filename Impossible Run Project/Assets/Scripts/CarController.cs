using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CarController : MonoBehaviour {

    public AudioSource sonidoMotor;
    private float pitch = 0.20f;

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

    public Light luzTraIzq;
    public Light luzTraDer;

    public GameObject lastMarker;

	// Use this for initialization
	void Start () {
        giroRuedas = 0.0f;
        maxGiroRuedas = 25.0f;
        fuerzaMotor = 0.0f;
        maxFuerzaMotor = 2500.0f;
        fuerzaFrenado = 4000.0f;
        estoyFrenando = false;
        fuerzaDerrape = 1000.0f;
        estoyDerrapando = false;

        posCentroDeMasas = new Vector3(0.0f, 0.0f, 0.0f);

        this.gameObject.GetComponent<Rigidbody>().centerOfMass = posCentroDeMasas; // le asignamos el centro de masas al vehículo
	}
	
	// Update is called once per frame
	void Update () {
        if (fuerzaMotor != 0)
        {
            pitch = fuerzaMotor / maxFuerzaMotor;
        } else if (pitch < 0.20)
        {
            pitch = 0.20f;
        }
        sonidoMotor.pitch = pitch;

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

        if (Input.GetKey(KeyCode.R))
        {
            this.transform.position = lastMarker.transform.position;
            
            //reseteamos las constraints del componente Rigidbody del coche , congelandolas y volviendole a asignar las que tenía para hacer que el GameObject pierda la inercia de movimiento
            RigidbodyConstraints auxConstraints = this.GetComponent<Rigidbody>().constraints;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.GetComponent<Rigidbody>().constraints = auxConstraints;

            //dejamos el eje x y z de la rotacion del componente transform del objeto para ponerlo plano al suelo
            this.transform.rotation = new Quaternion(0.0f, this.transform.rotation.y, 0.0f, this.transform.rotation.w);
            fuerzaMotor = 0.0f;
            rotacionRueda = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
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
            luzTraDer.intensity = 7;
            luzTraIzq.intensity = 7;
        }
        else
        {
            ruedaDelDer.brakeTorque = 0.0f;
            ruedaDelIzq.brakeTorque = 0.0f;
            ruedaTraDer.brakeTorque = 0.0f;
            ruedaTraIzq.brakeTorque = 0.0f;
            luzTraDer.intensity = 1.7f;
            luzTraIzq.intensity = 1.7f;
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
    }
}
