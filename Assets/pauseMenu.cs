using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class pauseMenu : MonoBehaviour
{
    public FirstPersonController controller;
    bool paused = false;

    public GameObject pausePanel;

    public bool isPaused;

    // Use this for initialization
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            PauseGame(true);
        }
        else
        {
            PauseGame(false);
        }

        if (Input.GetKey("p"))
        {
            SwitchPause();
        }
    }

    void PauseGame(bool state)
    {
        if (state)
        {
            controller.enabled = false;
            Time.timeScale = 0.0f; //Paused
        }
        else
        {
            controller.enabled = true;
            Time.timeScale = 1.0f; // Unpaused
        }
        pausePanel.SetActive(state);
    }

    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false; //Changes the value
        }
        else
        {
            isPaused = true;
        }
    }
}
