using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabChecker : MonoBehaviour
{
    private XRGrabInteractable xrGrabInteractable;
    private GameObject parentGo;
    [SerializeField] bool isGrabbed = false;
    [SerializeField] bool isSocketed = false;

    private void Start()
    {
        transform.SetParent(null);

        parentGo = new GameObject { name = "ParentOfGrabbed" };
        parentGo.transform.position = transform.position;

        xrGrabInteractable = GetComponent<XRGrabInteractable>();

        xrGrabInteractable.selectEntered.AddListener(OnGrabEntered);
        xrGrabInteractable.selectExited.AddListener(OnGrabExited);
    }
    // !! 중요 !!
    // Grab중인 것은 Scale 변화 불가능임..... Exited에서 scale변화 줘야함 !!!
    // 그래서 parent오브젝트를 줄이기로,,

    // if didn't add listener, set this method is public then add events at grab interactable's select in inspector 
    public void OnGrabEntered(SelectEnterEventArgs arg0)
    {
        if (arg0.interactorObject.transform.CompareTag("ObjectPlace"))
        {
            print("ObjectPlace");
            if(arg0.interactableObject.transform.GetComponent<Collider>() != null)
                arg0.interactableObject.transform.GetComponent<Collider>().isTrigger = true;
            foreach (Transform child in arg0.interactableObject.transform)
            {
                // 자식 오브젝트의 Collider 컴포넌트를 가져옵니다.
                Collider childCollider = child.GetComponent<Collider>();
                if (childCollider != null)
                    childCollider.isTrigger = true;
            }
            return;
        }
            

        parentGo.transform.position = transform.position;
        if (arg0.interactorObject is XRRayInteractor)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            arg0.interactableObject.transform.parent = parentGo.transform;
            arg0.interactableObject.transform.parent.localScale = Vector3.one * 0.1f;
        }
        // 소켓에 들어갈 때
        else if (arg0.interactorObject is XRSocketInteractor)
        {
            // ray에 의해 grab된 상태
            gameObject.GetComponent<Collider>().isTrigger = false;
            arg0.interactableObject.transform.parent = parentGo.transform;
            arg0.interactableObject.transform.parent.localScale = Vector3.one * 0.1f;
        }
    }

    public void OnGrabExited(SelectExitEventArgs arg0)
    {
        if (arg0.interactorObject.transform.CompareTag("ObjectPlace"))
        {
            print("ObjectPlace");
            if (arg0.interactableObject.transform.GetComponent<Collider>() != null)
                arg0.interactableObject.transform.GetComponent<Collider>().isTrigger = false;
            foreach (Transform child in arg0.interactableObject.transform)
            {
                // 자식 오브젝트의 Collider 컴포넌트를 가져옵니다.
                Collider childCollider = child.GetComponent<Collider>();
                if(childCollider != null)
                    childCollider.isTrigger = false;
            }
            return;
        }
        parentGo.transform.position = transform.position;
        if (arg0.interactorObject is XRRayInteractor || arg0.interactorObject is XRSocketInteractor)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;

            arg0.interactableObject.transform.parent = parentGo.transform;
            arg0.interactableObject.transform.parent.localScale = Vector3.one;
            arg0.interactableObject.transform.parent = null;
            transform.localScale = Vector3.one;
        }
        // 소켓에서 나올 때
        //else if (arg0.interactorObject is XRSocketInteractor) 
        //{
        //    arg0.interactableObject.transform.parent.localScale = Vector3.one;
        //    arg0.interactableObject.transform.SetParent(null);
        //    transform.localScale = Vector3.one;
        //    print(3);
        //}
    }
}
