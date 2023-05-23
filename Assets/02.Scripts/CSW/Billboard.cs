using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;
    
    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        tr.LookAt(camTr.position);
    }
}
