using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    Transform tempTrans;
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Furniture"))
        {
            tempTrans = other.transform.parent;
            other.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (CompareTag("Furniture"))
        {
            other.transform.parent = tempTrans;
        }
    }
}
