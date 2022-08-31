using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualObject : MonoBehaviour
{
    public Material myMaterial;
    Mesh mesh;
    MeshRenderer renderer;
    MeshFilter filter;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        Vector3[] verts = new Vector3[3];
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(1, 0, 0);
        verts[2] = new Vector3(1, 1, 0);
        Vector2[] uvs = new Vector2[3];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(1, 1);

        int[] inds = new int[] { 0, 1, 2, 2, 1, 0 };

        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.SetIndices(inds, MeshTopology.Triangles, 0);

        renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = myMaterial;
        filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
