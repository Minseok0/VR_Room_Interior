using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSlot : MonoBehaviour
{
    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        var interatable = args.interactableObject;

        print("OnHoverEnter" );
        //interatable.transform.GetComponent<XRGrabInteractable>(). = false;

        //args.interactableObject.transform.localScale = Vector3.one * 0.5f;
        //StartCoroutine(ScaleBiggerSmaller(args.interactableObject.transform));
    }
    public void OnHoverExit(HoverExitEventArgs args)
    {
        print("OnHoverExit" );
        //args.interactableObject.transform.localScale = Vector3.one;
        //StartCoroutine(ScaleBiggerSmaller(args.interactableObject.transform));

    }
    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        /*print("0" + args.interactableObject.transform.GetHashCode());
        args.interactableObject.transform.localScale = Vector3.one*0.5f;
        print(args.interactableObject.transform.localScale);
        StartCoroutine(ScaleBiggerSmaller(args.interactableObject.transform));*/
    }
    public void OnSelectExit(SelectExitEventArgs args)
    {
       /* print("1" + "SocketSlot select exit");
        print(args.interactableObject.transform.GetHashCode());
        args.interactableObject.transform.localScale = Vector3.one;
        print(args.interactableObject.transform.localScale);
        StartCoroutine(ScaleBiggerSmaller(args.interactableObject.transform));*/
    }

    

}
