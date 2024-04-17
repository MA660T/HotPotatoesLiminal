using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    [Header("SETUP VARIABLES")]
    [Tooltip("Add the collider of THIS INSTANCE of the Player Hand")]
    public Collider myCollider;
    public event Action<Collider, Collision> hitEvent;
    

    AudioSource SFX;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (myCollider.name == "PHandCollision")
        {
            StartCoroutine(Haptics(1, 1, 0.3f, true, false));
            SFX.Play();
            StartCoroutine(Haptics(1, 1, 0.3f, false, true));
        }


        else if (myCollider.name == "SHandCollision")
        {
            StartCoroutine(Haptics(1, 1, 0.3f, true, false));
            SFX.Play();
            StartCoroutine(Haptics(1, 1, 0.3f, false, true));
        }

    }

    IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if (myCollider.name == "PHandCollision")
        {
            OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
            yield return new WaitForSeconds(duration);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
        else if(myCollider.name == "SHandCollision") 
        {
            OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
            yield return new WaitForSeconds(duration);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

        }

    }
}
