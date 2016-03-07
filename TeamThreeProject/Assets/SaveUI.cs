using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUI : MonoBehaviour {

    public GameObject[] menu;
    public GameObject[] saveButton;
    //public GameObject file1Button;

    public List<PlayerPathStats> savedStats = new List<PlayerPathStats>();

    // Use this for initialization
    void Start()
    {
        menu[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile1.gd"))
        {
            saveButton[0].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 1";
        }

        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile2.gd"))
        {
            saveButton[1].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 2";
        }

        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile3.gd"))
        {
            saveButton[2].GetComponentInChildren<UnityEngine.UI.Text>().text = "File 3";
        }
    }

    public void ReturnToMenu()
    {
        menu[2].SetActive(false);
        menu[0].SetActive(true);
    }

    public void file1()
    {
        savedStats.Clear();
        File.Delete(Application.persistentDataPath + "/saveFile1.gd");
        savedStats.Add(PlayerPathStats.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile1.gd");
        bf.Serialize(file, savedStats);
        file.Close();
    }

    public void file2()
    {
        savedStats.Clear();
        File.Delete(Application.persistentDataPath + "/saveFile2.gd");
        savedStats.Add(PlayerPathStats.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile2.gd");
        bf.Serialize(file, savedStats);
        file.Close();
    }

    public void file3()
    {
        savedStats.Clear();
        File.Delete(Application.persistentDataPath + "/saveFile3.gd");
        savedStats.Add(PlayerPathStats.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile3.gd");
        bf.Serialize(file, savedStats);
        file.Close();
    }
}
