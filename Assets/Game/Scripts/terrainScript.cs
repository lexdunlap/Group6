using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainScript : MonoBehaviour {
    int heightScale = 3;
    float detailScale = 10.0f;
	// Use this for initialization
	void Start ()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for(int i =0;i<vertices.Length;i++)
        {
            vertices[i].y = Mathf.PerlinNoise((vertices[i].x + this.transform.position.x) / detailScale, (vertices[i].z + this.transform.position.z) / detailScale) * heightScale;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
