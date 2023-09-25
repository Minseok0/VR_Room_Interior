// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySystem : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    public bool UIActive;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}