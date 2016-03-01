using UnityEngine;
using System.Collections;

public class CameraPathFinding : MonoBehaviour {
    GameObject player;
    BattlePath battle;
    void Start()
    {
        battle = GameObject.FindGameObjectWithTag("Battle").GetComponent<BattlePath>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(-0.47f, 32.07f, -1.46f);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vec1 = new Vector3(player.transform.position.x, 32.07f, -1.46f);
        Vector3 temp = Vector3.Lerp(transform.position, vec1, 1);
        transform.position = Vector3.Lerp(transform.position, vec1, 1);

        if (transform.position.x >= -0.47f)
        {
            transform.position = new Vector3(-0.47f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= 0.49f)
        {
            transform.position = new Vector3(-0.49f, transform.position.y, transform.position.z);
        }
        //if (transform.position.y > 4.4f)
        //{
        //    transform.position = new Vector3(transform.position.x, 4.4f, transform.position.z);
        //}
    }
}
