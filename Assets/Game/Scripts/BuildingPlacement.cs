using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    private PlaceableBuilding placeableBuilding;
    private Transform currentBuilding;
    private bool hasPlaced;
    public LayerMask buildingsMask;
    private PlaceableBuilding placeableBuildingOld;
    public LayerMask groundLayer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);

        if (currentBuilding != null&& !hasPlaced){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, Mathf.Infinity, groundLayer))
            {
                currentBuilding.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                IsLegalPosition();
            }
        }
        
        if (Input.GetMouseButtonDown(1)){
            if (IsLegalPosition())
            {
                hasPlaced = true;
            }
        }

        /**if (currentBuilding != null && !hasPlaced)
        {
            currentBuilding.position = new Vector3(p.x, 0, p.z);
            if (Input.GetMouseButtonDown(1))
            {
                if (IsLegalPosition())
                hasPlaced = true;
            }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x,8, p.z), Vector3.down);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask))
                {
                    hit.collider.GetComponent <PlaceableBuilding>().SetSelected(true);
                    placeableBuildingOld = hit.collider.GetComponent<PlaceableBuilding>();
                }
                else
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                }
            }
        }**/

	}

    bool IsLegalPosition()
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
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
    }
}
