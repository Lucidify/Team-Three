using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    GameObject player;
    int z = -10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 vec1 = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        Vector3 temp = Vector3.Lerp(transform.position, vec1, 1);
        transform.position = temp;
        transform.position = new Vector3(3.19f, transform.position.y, transform.position.z);
        if (transform.position.y <= 2)
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        }
        if (transform.position.y > 4.4f)
        {
            transform.position = new Vector3(transform.position.x, 4.4f, transform.position.z);
        }
    }
}
