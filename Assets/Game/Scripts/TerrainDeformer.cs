using UnityEngine;
using System.Collections;

public class TerrainDeformer : MonoBehaviour
{
    public Terrain terrain;
    public float strength = 0.01f;

    private int heightmapWidth;
    private int heightmapHeight;
    private float[,] heights;
    private TerrainData terrainData;

    void Start()
    {
        terrainData = terrain.terrainData;
        Debug.Log(terrainData);
        heightmapWidth = terrainData.heightmapWidth;
        heightmapHeight = terrainData.heightmapHeight;
        heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);

    }

    void Update()
    {
          RaycastHit hit;
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

          //raise terrain
          if (Input.GetMouseButton(0))
          {
              if(Physics.Raycast(ray,out hit))
              {
                  RaiseTerrain(hit.point);
              }
          }
          //lower terrain
          if (Input.GetMouseButton(1))
          {
              if(Physics.Raycast(ray, out hit))
              {
                  LowerTerrain(hit.point);
              }
          }
 
        }
    


    //functions
    public void RaiseTerrain(Vector3 point)
    {
        int mouseX = (int)((point.x / terrainData.size.x) * heightmapWidth);
        int mouseZ = (int)((point.z / terrainData.size.z) * heightmapHeight);
        float[,] modifiedHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y += strength * Time.deltaTime;

        if (y > terrainData.size.y)
        {
            y = terrainData.size.y;
        }

        modifiedHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        terrainData.SetHeights(mouseX, mouseZ, modifiedHeights);

    }

    public void LowerTerrain(Vector3 point)
    {
        int mouseX = (int)((point.x / terrainData.size.x) * heightmapWidth);
        int mouseZ = (int)((point.z / terrainData.size.z) * heightmapHeight);
        float[,] modifiedHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y -= strength * Time.deltaTime;

        if (y < 0)
        {
            y = 0;
        }

        modifiedHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        terrainData.SetHeights(mouseX, mouseZ, modifiedHeights);

    }
}    