using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour {

    Transform t;
    float fixedRotation;

	// Use this for initialization
	void Start () {
        t = transform;
        fixedRotation = t.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, fixedRotation);
	}
}
