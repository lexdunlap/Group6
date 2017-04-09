using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSVR.Unity;

public class assetMenu : MonoBehaviour
{
    [SerializeField]
    public VRViewer viewer;
    private bool spacePressed;
    private PlaceableBuilding placeableBuilding;
    public Transform currentBuilding;
    private bool hasPlaced;
    private bool moveObject;
    public LayerMask buildingsMask;
    public LayerMask groundLayer;
    private int spaceCount = 0;
    private int moveCount = 0;
    public GameObject canvas;
    public GameObject radialMenu;
    public GameObject tempGO;

    void Start()
    {
        //terrainScript = GetComponent<TerrainDeformer>();
        //terrainScript1 = GetComponent<TerrainDeformer1>();
        viewer = GetComponent<VRViewer>();
        placeableBuilding = GetComponent<PlaceableBuilding>();
        hasPlaced = false;
        spacePressed = false;
        moveObject = false;
        //Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            spacePressed = true;
            spaceCount++;
        }

        else if (Input.GetMouseButtonDown(0) && spacePressed != true)
        {
            radialMenu.SetActive(true);
            gameObject.GetComponent<ObjectCircularMenu>().enabled = true;
            moveObject = true;
            moveCount++;
        }

        else
        {
            if (spacePressed && spaceCount == 1)
            {
                getMouseLocation();
            }
            
            else if (moveObject && moveCount == 1)
            {
                ObjectCircularMenu radialMenu1 = gameObject.GetComponent<ObjectCircularMenu>();

                Debug.Log(radialMenu1.CurMenuItems);
                radialMenu.SetActive(false);
                viewer.enabled =(true);
                Ray ray = viewer.Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
				getMouseLocation ();
				if (Input.GetMouseButtonDown(0))
				{
						if (Physics.Raycast(ray, out hit))
						{
							Transform m = hit.transform;
							tempGO = m.gameObject;
							Destroy (currentBuilding.gameObject);
							SetItem (tempGO);

							IsLegalPosition ();
                        moveCount = 0;
						}
				}
            }
            else
            {
                spaceCount = 0;
                moveCount = 0;
                spacePressed = false;
                //Cursor.lockState = CursorLockMode.Locked;
                canvas.SetActive(false);
            }
        }
    }

    public void getMouseLocation()
    {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);

        if (currentBuilding != null && !hasPlaced)
        {
            Ray ray = viewer.Camera.ScreenPointToRay(m);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000000, groundLayer))
            {
                currentBuilding.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                IsLegalPosition();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (IsLegalPosition())
            {
                hasPlaced = true;
            }
        }
    }
    public bool IsLegalPosition()
    {
        if (placeableBuilding.colliders.Count > 0)
        {
            return false;
        }
        return true;

    }
    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform; ;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
    }


    public void radial0()
    {
        
    }
    public void radial1()
    {

    }
    public void radial2()
    {

    }
    public void radial3()
    {

    }
}

//code for terrain modifying
/*
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        terrainScript.RaiseTerrain(hit.point);
                    }
                }

				//right click to destroy terrain
                if (Input.GetMouseButtonDown(1))
                {

                    if (Physics.Raycast(ray, out hit))
                    {
                        
                        Debug.Log(hit.transform);    
                        Transform m = hit.transform;
                        currentBuilding = m;
                        if(currentBuilding.name == "Terrain")
                        {
                            Debug.Log(hit.point);
                            terrainScript1.DestroyTerrain(hit.point,5.0f);

                        }
                    }
                }
			*/


