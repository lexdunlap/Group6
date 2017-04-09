using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSVR.Unity;

public class BuildingSystem : MonoBehaviour
{

    public VRViewer viewer;
    public List<buildObjects> objects = new List<buildObjects>();
    private buildObjects currentObjects;
    private Vector3 currentpos;
    private Vector3 currentRot;
    public Transform currentPreview;
    public RaycastHit hit;
    public LayerMask layer;
    public float offset = 1.0f;
    public float gridSize = 1.0f;
    public bool building;
    private bool chooseobj;
	// Use this for initialization
	void Start ()
    {
        viewer = GetComponent<VRViewer>();
        ChangeCurrentBuilding(0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
    void Update()
    {
        if(building)
        {
            startPreview();
        }
        if(Input.GetMouseButtonDown(0))
        {
            Build();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ChangeCurrentBuilding(int cur)
    {
        currentObjects = objects[cur];
        if(currentPreview!=null)
        {
            Destroy(currentPreview.gameObject);
        }
        Transform curprev = ((GameObject)Instantiate(currentObjects.preview)).transform;
        currentPreview = curprev.transform;
    }
    public void startPreview()
    {
        Ray ray = viewer.Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000000, layer))
            if (hit.transform != this.transform)
                showPreview(hit);
    }
    public void showPreview(RaycastHit hit2)
    {
        currentpos = hit2.point;
        currentpos -= Vector3.one * offset;
        currentpos /= gridSize;
        currentpos = new Vector3(Mathf.Round(currentpos.x), Mathf.Round(hit2.point.y), Mathf.Round(currentpos.z));
        currentpos *= gridSize;
        currentpos += Vector3.one * offset;
        currentPreview.position = currentpos;

        if(Input.GetMouseButtonDown(1))
        {
            currentRot += new Vector3(0, 90, 0);
        }
        currentPreview.localEulerAngles = currentRot;
    }
    public void Build()
    {
        BuildObject BO = currentPreview.GetComponent<BuildObject>();
        if(BO.isBuildable)
        {

            Instantiate(currentObjects.prefab, currentpos, Quaternion.Euler(currentRot));
        }
    }
}
[System.Serializable]
public class buildObjects
{
    public string name;
    public GameObject prefab;
    public GameObject preview;
    public int gold;
}
