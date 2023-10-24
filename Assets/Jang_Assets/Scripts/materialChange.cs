using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Furniture"))
            other.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Material>();
        Destroy(gameObject);
    }
}
