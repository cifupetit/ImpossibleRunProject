using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

    public Camera topCamera;
    public Camera hoodCamera;
    public Camera backCamera;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (topCamera.gameObject.activeInHierarchy == true)
            {
                topCamera.gameObject.SetActive(false);
                hoodCamera.gameObject.SetActive(true);
            }
            else
            {
                topCamera.gameObject.SetActive(true);
                hoodCamera.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            topCamera.gameObject.SetActive(false);
            hoodCamera.gameObject.SetActive(false);
            backCamera.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            topCamera.gameObject.SetActive(true);
            hoodCamera.gameObject.SetActive(false);
            backCamera.gameObject.SetActive(false);
        }
    }
}
