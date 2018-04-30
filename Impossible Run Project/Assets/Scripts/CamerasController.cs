using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour {

    public Camera TopCamera;
    public Camera HoodCamera;
    public Camera BackCamera;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (TopCamera.gameObject.activeInHierarchy == true)
            {
                TopCamera.gameObject.SetActive(false);
                HoodCamera.gameObject.SetActive(true);
            }
            else
            {
                TopCamera.gameObject.SetActive(true);
                HoodCamera.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TopCamera.gameObject.SetActive(false);
            HoodCamera.gameObject.SetActive(false);
            BackCamera.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            TopCamera.gameObject.SetActive(true);
            HoodCamera.gameObject.SetActive(false);
            BackCamera.gameObject.SetActive(false);
        }
    }
}
