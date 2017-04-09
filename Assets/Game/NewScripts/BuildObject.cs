using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    public bool f;
    public List<Collider> col = new List<Collider>();
    public Material green;
    public Material red;
    public bool isBuildable;
	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer!=9 &&f)
        {
            col.Add(other);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 9 && f)
            col.Remove(other);
    }
    public void changeColor()
    {
        if (col.Count == 0)
            isBuildable = true;
        else
            isBuildable = false;
        if(isBuildable)
        {
                GetComponent<Renderer>().material = green;

        }
        else
        {
                GetComponent<Renderer>().material = red;
        }
    }
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        changeColor();
	}
}
