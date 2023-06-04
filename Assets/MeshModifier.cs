using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshModifier : MonoBehaviour
{
    private MeshFilter meshFilter;
    [SerializeField] public GameObject left;
    Vector3 leftP;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        leftP = left.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if( leftP != left.transform.position)
        ModifyMesh(meshFilter.mesh);
    }

    private void ModifyMesh(Mesh mesh)
    {
        if (!mesh)
        {
            return;
        }

        Vector3[] vertices = mesh.vertices;

        // Modify vertices (Move all the vertices one unit to the right)
        
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            if (vertices[i].x > 0)
            {
                vertices[i].x += (left.transform.position.x - leftP.x)*1.5f;
            }
        }
        leftP = left.transform.position;
        mesh.vertices = vertices;
    }
}
