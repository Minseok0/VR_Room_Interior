using System.Collections;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor;

    public XRRayInteractor xRRayInteractor;

    public Transform objectInHand;

    FixedJoint joint;

    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;

        joint = GetComponent<FixedJoint>();
    }

    private void OnEnable()
    {
        xRRayInteractor.selectEntered.AddListener(OnSelectEntering);
        xRRayInteractor.selectExited.AddListener(OnSelectExiting);
    }
    private void OnDisable()
    {
        xRRayInteractor.selectEntered.RemoveListener(OnSelectEntering);
        xRRayInteractor.selectExited.RemoveListener(OnSelectExiting);
    }
    private void OnSelectEntering(SelectEnterEventArgs args)
    {
        //Debug.Log("args.interactableObject : " + args.interactableObject.transform.name);
        objectInHand = args.interactableObject.transform;
    }
    private void OnSelectExiting(SelectExitEventArgs args)
    {
        objectInHand = null;
    }

    public void ColorChange()
    {
        if (objectInHand != null)
        {
            slotImage.color = Color.gray;
        }
    }

    public void Contact()
    {
        if (ItemInSlot != null) return;
        if (!IsItem(objectInHand.gameObject)) return;
        if(objectInHand != null) {
            InsertItem(objectInHand.gameObject);
        }
    }

    public void Delete()
    {
        if (objectInHand == null)
        {
            RemoveItem(ItemInSlot);
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        
        joint.connectedBody = obj.GetComponent<Rigidbody>(); // Slot에 고정
        slotImage.color = Color.gray;

        if (obj.GetComponent<InventorySystem>().UIActive == false)
        {
            Debug.Log("1");
            obj.SetActive(false);
        }
        if (obj.GetComponent<InventorySystem>().UIActive == true)
        {
            obj.SetActive(true);
        }
    }

    public void RemoveItem(GameObject obj)
    {
        if (ItemInSlot != null)
        {
            joint.connectedBody = null;

            ItemInSlot.transform.SetParent(null, true);
            ItemInSlot.GetComponent<Rigidbody>().isKinematic = false;
            ItemInSlot.GetComponent<Item>().inSlot = false;
            ItemInSlot.GetComponent<Item>().currentSlot = null;
            ItemInSlot = null;

            joint.connectedBody = null; // Slot 고정 해제
            ResetColor();
        }
    }


    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
