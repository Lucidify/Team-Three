using UnityEngine;
using System.Collections;

public class ReturnToTown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnToTowm()
    {
        Application.LoadLevel(0);
    }
}
