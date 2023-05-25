using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Furniture"))
            other.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Material>();
        Destroy(gameObject);
    }
}
