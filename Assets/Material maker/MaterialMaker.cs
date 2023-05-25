using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMaker : MonoBehaviour
{
    public Material material;
    public GameObject Matball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateMat()
    {
        Instantiate(Matball);
        Instantiate(material);
        Matball.GetComponent<Renderer>().material = material;
        Matball.transform.position = gameObject.transform.position;
    }

}
