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
    // !! �߿� !!
    // Grab���� ���� Scale ��ȭ �Ұ�����..... Exited���� scale��ȭ ����� !!!
    // �׷��� parent������Ʈ�� ���̱��,,

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
                // �ڽ� ������Ʈ�� Collider ������Ʈ�� �����ɴϴ�.
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
        // ���Ͽ� �� ��
        else if (arg0.interactorObject is XRSocketInteractor)
        {
            // ray�� ���� grab�� ����
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
                // �ڽ� ������Ʈ�� Collider ������Ʈ�� �����ɴϴ�.
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
        // ���Ͽ��� ���� ��
        //else if (arg0.interactorObject is XRSocketInteractor) 
        //{
        //    arg0.interactableObject.transform.parent.localScale = Vector3.one;
        //    arg0.interactableObject.transform.SetParent(null);
        //    transform.localScale = Vector3.one;
        //    print(3);
        //}
    }
}
