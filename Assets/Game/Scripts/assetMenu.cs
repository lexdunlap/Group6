using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSVR.Unity;

public class assetMenu : MonoBehaviour
{

    private VRViewer viewer;
    private bool spacePressed;
    private PlaceableBuilding placeableBuilding;
    private Transform currentBuilding;
    private bool hasPlaced;
    public LayerMask buildingsMask;
    public LayerMask groundLayer;
    private int spaceCount = 0;
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
        viewer = GetComponent<VRViewer>();
        placeableBuilding = GetComponent<PlaceableBuilding>();
        hasPlaced = false;
        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            spacePressed = true;
            spaceCount++;
        }
        if (spacePressed && spaceCount ==1)
        {
            getMouseLocation();
        }
        else
        {
            spaceCount = 0;
            Cursor.lockState = CursorLockMode.Locked;
            canvas.SetActive(false);
        }

    }
    void getMouseLocation()
    {
        VRViewer viewer = FindObjectOfType<VRViewer>();
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p1 = viewer.Camera.ScreenToWorldPoint(m);

        if (currentBuilding != null && !hasPlaced)
        {
            Ray ray = viewer.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                currentBuilding.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
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




