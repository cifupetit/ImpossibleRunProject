using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundController : MonoBehaviour {

    public AudioSource carSound;
    public GameObject imageActiveSound;
    public GameObject imageMuteSound;
    private bool active = true;

	public void controlSound()
    {
        if (active)
        {
            active = false;
            imageActiveSound.SetActive(false);
            imageMuteSound.SetActive(true);
            carSound.enabled = false;
        }
        else
        {
            active = true;
            imageActiveSound.SetActive(true);
            imageMuteSound.SetActive(false);
            carSound.enabled = true;
        }
    }
}
