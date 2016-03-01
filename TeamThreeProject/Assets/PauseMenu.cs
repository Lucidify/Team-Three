using UnityEngine;
using System.Collections;


public class PauseMenu : MonoBehaviour {

    public GameObject [] menu;
    
    
    //public GameObject LoadUI;

    private bool paused = false;

    

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
        /*savedStats.Add(PlayerPathStats.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedStats.gd");
        bf.Serialize(file, PauseMenu.savedStats);
        file.Close();*/
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
            Time.timeScale = 1;
        }
    }
}
