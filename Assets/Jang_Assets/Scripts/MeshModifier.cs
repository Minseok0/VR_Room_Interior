using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshModifier : MonoBehaviour
{
    private MeshFilter meshFilter;
    public meshUIControl meshUIControl;
    [SerializeField] public GameObject left;
    [SerializeField] public GameObject right;
    [SerializeField] public GameObject up;
    [SerializeField] public GameObject down;
    [SerializeField] public GameObject front;
    [SerializeField] public GameObject back;
    Vector3 leftP;
    Vector3 rightP;
    Vector3 upP;
    Vector3 downP;
    Vector3 frontP;
    Vector3 BackP;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        //meshFilter = meshUIControl.target.GetComponent<MeshFilter>();
        leftP = left.transform.position;
        rightP = right.transform.position;
        upP = up.transform.position;
        downP = down.transform.position;
        frontP = front.transform.position;
        BackP = back.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(leftP, left.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,0);
        if (Vector3.Distance(rightP, right.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,1);
        if (Vector3.Distance(upP, up.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,2);
        if (Vector3.Distance(downP, down.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,3);
        if (Vector3.Distance(frontP, front.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,4);
        if (Vector3.Distance(BackP, back.transform.position) > 0.1)
            ModifyMesh(meshFilter.mesh,5);
    }

    private void ModifyMesh(Mesh mesh, int mod)
    {
        if (!mesh)
        {
            return;
        }

        Vector3[] vertices = mesh.vertices;

        // Modify vertices (Move all the vertices one unit to the right)
        switch (mod)
        {
            case 0:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].x > 0)
                    {
                        vertices[i].x += (left.transform.position.x - leftP.x) * 3f;
                    }
                }
                leftP = left.transform.position;
                mesh.vertices = vertices;
                break;
            case 1:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].x < 0)
                    {
                        vertices[i].x += (right.transform.position.x - rightP.x) * 3f;
                    }
                }
                rightP = right.transform.position;
                mesh.vertices = vertices;
                break;
            case 2:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].y > 0)
                    {
                        vertices[i].y += (up.transform.position.y - upP.y) * 3f;
                    }
                }
                upP = up.transform.position;
                mesh.vertices = vertices;
                break;
            case 3:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].y < 0)
                    {
                        vertices[i].y += (down.transform.position.y - downP.y) * 3f;
                    }
                }
                downP = down.transform.position;
                mesh.vertices = vertices;
                break;
            case 4:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].z > 0)
                    {
                        vertices[i].z += (front.transform.position.z - frontP.z) * 3f;
                    }
                }
                frontP = front.transform.position;
                mesh.vertices = vertices;
                break;
            case 5:
                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    if (vertices[i].z < 0)
                    {
                        vertices[i].z += (back.transform.position.z - BackP.z) * 3f;
                    }
                }
                BackP = back.transform.position;
                mesh.vertices = vertices;
                break;




        }
        
    }
   
}
