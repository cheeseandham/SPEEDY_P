using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Surface_Creator : MonoBehaviour
{
    private Mesh mesh;
    EdgeCollider2D edgeCol;
    
    Vector3[] verts;

    public int quadMin;
    public int quadMax;
    public int ranYRange;
    public int offsetX;
    public int offsetY;

    public float greenHeight;
    public float greenWidth;

    GameObject control;
    Game_Controller gm;

    GameObject nextGreenRef;
    
    void Start () {
        if (mesh == null)
        {
            mesh = new Mesh();
            mesh.name = "Surface Mesh";
            GetComponent<MeshFilter>().mesh = mesh;
        }

        if (edgeCol == null)
        {
            edgeCol = GetComponent<EdgeCollider2D>();
        }

        control = GameObject.FindGameObjectWithTag("GameController");
        gm = control.GetComponent<Game_Controller>();

        nextGreenRef = transform.GetChild(0).gameObject;
        New_Surface();
    }
	
    void New_Surface()
    {
        Add_Verts();
    }

    void Add_Verts()
    {
        int quadCount = Random.Range(quadMin, quadMax);
        verts = new Vector3[(quadCount + 1) * 2];
        Vector2[] edges = new Vector2[quadCount + 1];

        int[] ranYs = new int[quadCount + 1];
        for (int r = 0; r < quadCount + 1; r++)
        {
            int ran = Random.Range(-ranYRange, ranYRange + 1) * 5;
            ranYs[r] = ran;
        }
        
        for (int y = 0, v = 0; y < 2; y++)
        {
            int i = 0;
            for (int x = 0; x < quadCount + 1; x++, v++)
            {
                verts[v] = new Vector3(x * offsetX, i + (greenHeight * y));
                i += ranYs[x];
                if (y == 1)
                {
                    edges[x] = verts[v];
                }
                if (y == 0 && x == quadCount)
                {
                    nextGreenRef.transform.localPosition = verts[v];
                    gm.greenSpawn = nextGreenRef.transform;
                }
            }
        }

        edgeCol.points = edges;
        mesh.vertices = verts;

        Set_Tri();
    }

    void Set_Tri()
    {
        int single = verts.Length / 2;
        int[] triangles = new int[(single - 1) * 6];

        for (int x = 0, t = 0, v = 0; x < single - 1; x++, v++)
        {
            triangles[t] = v;
            triangles[t + 1] = v + single;
            triangles[t + 2] = v + 1;
            triangles[t + 3] = v + 1;
            triangles[t + 4] = v + single;
            triangles[t + 5] = v + single + 1;
            t += 6;
        }

        mesh.triangles = triangles;
    }

}
