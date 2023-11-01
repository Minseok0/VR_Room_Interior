using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Furniture"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
            /*if (gameObject.transform.parent.CompareTag("Furniture"))
                for(int i = 0; i < gameObject.transform.parent.childCount; i++)
                {
                    gameObject.transform.parent.GetChild(i).GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
                }    */
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
