using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadUI : MonoBehaviour {

    public GameObject[] menu;

    public static List<PlayerPathStats> savedStats = new List<PlayerPathStats>();

    // Use this for initialization
    void Start () {
        menu[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (File.Exists(Application.persistentDataPath + "/savedStats.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedStats.gd", FileMode.Open);
            LoadUI.savedStats = (List<PlayerPathStats>)bf.Deserialize(file);
            file.Close();
        }
    }

    public void ReturnToMenu()
    {
        menu[1].SetActive(false);
        menu[0].SetActive(true);
    }
}
