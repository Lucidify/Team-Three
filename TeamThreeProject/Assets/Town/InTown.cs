using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InTown : MonoBehaviour {
    public Button button;
    public GameObject player;
	// Use this for initialization
	void Start () {
        button.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.Linecast(player.transform.position, player.transform.position, 1 << LayerMask.NameToLayer("Portal")))
        {
            Debug.Log("Portal");
            button.gameObject.SetActive(true);
        }
        else
            button.gameObject.SetActive(false);
    }

    public void LoadMap()
    {
        Application.LoadLevel(3);
    }
}
