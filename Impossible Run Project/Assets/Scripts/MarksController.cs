using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksController : MonoBehaviour {

    public GameObject theMarker;
    public GameObject mark01;
    public GameObject mark02;
    public GameObject mark03;
    public GameObject mark04;
    public GameObject mark05;
    public GameObject mark06;
    public int markTracker;
    public CuentaAtras cuentaAtras;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (markTracker == 0)
        {
            theMarker.transform.position = mark01.transform.position;
        }
        if (markTracker == 1)
        {
            theMarker.transform.position = mark02.transform.position;
        }
        if (markTracker == 2)
        {
            theMarker.transform.position = mark03.transform.position;
        }
        if (markTracker == 3)
        {
            theMarker.transform.position = mark04.transform.position;
        }
        if (markTracker == 4)
        {
            theMarker.transform.position = mark05.transform.position;
        }
        if (markTracker == 5)
        {
            theMarker.transform.position = mark06.transform.position;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SkyCar")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            markTracker++;
            cuentaAtras.Start();
            if (markTracker == 6)
            {
                markTracker = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
