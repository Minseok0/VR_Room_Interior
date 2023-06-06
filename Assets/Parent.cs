using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    Transform tempTrans;
    private void OnTriggerEnter(Collider other)
    {
        tempTrans = other.transform.parent;
        other.transform.parent = gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = tempTrans;
    }
}
