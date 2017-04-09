using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {

    public radialButton buttonPrefab;
    public radialButton selected;
    interactable objTemp;
	// Use this for initialization
	public void SpawnButtons (interactable obj)
    {
        for (int i = 0; i < obj.options.Length; i++)
        {
            objTemp = obj;
            radialButton newButton = Instantiate(buttonPrefab) as radialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f)*100f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
        }
	}


    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                switch (selected.title)
                {
                    case "Move":
                    {
                            Debug.Log(objTemp.name);
                            break;
                    }
                    case ("Delete"):
                    {
                            Debug.Log("delete this ish");
                            break;
                    }
                }
           
            }
            Destroy(gameObject);
        }
    }
	
}
