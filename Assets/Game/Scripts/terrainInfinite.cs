using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject tile;
    public float creationTime;

    public Tile(GameObject t,float ct)
    {
        tile = t;
        creationTime = ct;
    }
}

public class terrainInfinite : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;
    int planeSize = 10;
    int halfTilesX = 10;
    int halfTilesZ = 10;
    Vector3 startPos;
    Hashtable tiles = new Hashtable();
	// Use this for initialization
	void Start ()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int i = -halfTilesX; i < halfTilesX; i++)
        {
            for(int j =-halfTilesZ; j<halfTilesZ;j++)
            {
                Vector3 pos = new Vector3((i * planeSize + startPos.x), 0, (j * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                string tileName = "tile" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tileName;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tileName, tile);
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
