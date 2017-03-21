using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerPanel : MonoBehaviour
{
    public GameObject panel;
	// Use this for initialization
	void Start ()
    {
        Vector3 v = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane);
        panel.transform.position = Camera.main.ScreenToWorldPoint(v);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
