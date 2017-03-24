using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSVR.Unity;

public class alwaysInScreen : MonoBehaviour
{
    public Transform camera;
    public double distance = 5.0;	
	// Update is called once per frame
	void Update ()
    {
        Quaternion rotation = camera.rotation;
	}
}
