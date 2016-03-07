using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadUI : MonoBehaviour {

    public GameObject[] menu;
    public GameObject[] loadButton;

    public List<PlayerPathStats> savedStats = new List<PlayerPathStats>();

    // Use this for initialization
    void Start () {
        menu[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile1.gd"))
        {
            loadButton[0].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 1";
        }

        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile2.gd"))
        {
            loadButton[1].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 2";
        }

        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile3.gd"))
        {
            loadButton[2].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 3";
        }
    }

    public void ReturnToMenu()
    {
        menu[1].SetActive(false);
        menu[0].SetActive(true);
    }

    public void file1()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile1.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile1.gd", FileMode.Open);
            savedStats = (List<PlayerPathStats>)bf.Deserialize(file);
            file.Close();
            foreach (PlayerPathStats g in savedStats)
            {
                PlayerPathStats.current = g;
            }
        }
    }

    public void file2()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile2.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile2.gd", FileMode.Open);
            savedStats = (List<PlayerPathStats>)bf.Deserialize(file);
            file.Close();
            foreach (PlayerPathStats g in savedStats)
            {
                PlayerPathStats.current = g;
            }
        }
    }

    public void file3()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile3.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveFile3.gd", FileMode.Open);
            savedStats = (List<PlayerPathStats>)bf.Deserialize(file);
            file.Close();
            foreach (PlayerPathStats g in savedStats)
            {
                PlayerPathStats.current = g;
            }
        }
    }
}
