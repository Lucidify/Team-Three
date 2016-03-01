using UnityEngine;
using System.Collections;

public class MovementInTown : MonoBehaviour {
    float xPos;
    float yPos;
    RaycastHit2D playerStanding;
    public GameObject inventory;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.active == true)
                inventory.SetActive(false);
            else
                inventory.SetActive(true);
        }
        
            Movement();

    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            yPos = 0;
            xPos = -0.32f;
            // Check to see if can move in that direction
            if (Physics2D.Linecast(new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), 1 << LayerMask.NameToLayer("Floor")))
            {
                // If the player can move there
                transform.position = new Vector3(transform.position.x - 0.32f, transform.position.y, transform.position.z);
            }

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            yPos = 0;
            xPos = 0.32f;
            if (Physics2D.Linecast(new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), 1 << LayerMask.NameToLayer("Floor")))
            {
                transform.position = transform.position = new Vector3(transform.position.x + 0.32f, transform.position.y, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            yPos = 0.32f;
            xPos = 0;
            if (Physics2D.Linecast(new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), 1 << LayerMask.NameToLayer("Floor")))
            {
                transform.position = transform.position = new Vector3(transform.position.x, transform.position.y + 0.32f, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            yPos = -0.32f;
            xPos = 0;
            if (Physics2D.Linecast(new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z), 1 << LayerMask.NameToLayer("Floor")))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.32f, transform.position.z);
            }
        }
    }
}
