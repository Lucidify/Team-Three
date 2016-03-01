using UnityEngine;
using System.Collections;

[System.Serializable]

public class PlayerPathStats : MonoBehaviour {

    public static PlayerPathStats current;

    public int health = 20;
    public int attack = 10;
	// Use this for initialization
	void Start () {
        health = 100;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
