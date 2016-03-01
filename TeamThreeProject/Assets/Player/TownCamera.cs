using UnityEngine;
using System.Collections;

public class TownCamera : MonoBehaviour {
    GameObject player;
    int z = -10;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 vec1 = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        Vector3 temp = Vector3.Lerp(transform.position, vec1, 1);
        transform.position = temp;
        //transform.position = new Vector3(3.19f, transform.position.y, transform.position.z);
        if (transform.position.x >= 12.48)
        {
            transform.position = new Vector3(12.48f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= 3.200006)
        {
            transform.position = new Vector3(3.200006f, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= -13.92)
        {
            transform.position = new Vector3(transform.position.x, -13.92f, transform.position.z);
        }
        if (transform.position.y >= -1.920008)
        {
            transform.position = new Vector3(transform.position.x, -1.920008f, transform.position.z);
        }

    }
}
