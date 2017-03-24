using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour {

    public Button myButton;

    public void Start()
    {
        myButton = GetComponent<Button>();
    }
    void Awake()
     {
          // <-- you get access to the button component here
 
         myButton.onClick.AddListener( () => {myFunctionForOnClickEvent();} );  // <-- you assign a method to the button OnClick event here
     }
 
     void myFunctionForOnClickEvent()
     {
         // your code goes here
         SceneManager.LoadScene("Main");
     }
 }
