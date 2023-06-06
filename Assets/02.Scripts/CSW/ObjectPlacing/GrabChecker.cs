using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabChecker : MonoBehaviour
{
    private XRGrabInteractable xrGrabInteractable;

    private void Start()
    {
        xrGrabInteractable = GetComponent<XRGrabInteractable>();

        xrGrabInteractable.selectEntered.AddListener(OnGrabEntered);
        xrGrabInteractable.selectExited.AddListener(OnGrabExited);
    }

    // if didn't add listener, set this method is public then add events at grab interactable's select in inspector 
    private void OnGrabEntered(SelectEnterEventArgs arg0)
    { 
        //this.gameObject.AddComponent<PlacementChecker>();
        //this.gameObject.GetComponent<PlacementChecker>().
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }

    private void OnGrabExited(SelectExitEventArgs arg0)
    {
        //Destroy(this.gameObject.GetComponent<PlacementChecker>());
        this.gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
