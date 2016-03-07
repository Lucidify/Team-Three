using UnityEngine;
using System.Collections;


public class PauseMenu : MonoBehaviour {

    public GameObject [] menu;
    
    
    //public GameObject LoadUI;

    public bool paused = false;

    

    // Use this for initialization
    void Start () {
        menu[0].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            PausedUpdate();
        }

        
	}

    public void Resume()
    {
        paused = false;
        PausedUpdate();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Save()
    {
        menu[0].SetActive(false);
        menu[2].SetActive(true);
    }

    public void Load()
    {
        menu[0].SetActive(false);
        menu[1].SetActive(true);
    }

    void PausedUpdate()
    {
        if (paused)
        {
            menu[0].SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            menu[0].SetActive(false);
            menu[1].SetActive(false);
            menu[2].SetActive(false);
            Time.timeScale = 1;
        }
    }
}
