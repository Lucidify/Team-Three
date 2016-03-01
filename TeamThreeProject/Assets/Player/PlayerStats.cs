using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public enum Direction
    {
        UP,UPANDDOWN,LEFTANDRIGHT,UPDOWNLEFTRIGHT
    }
     public Direction playerMovement;
    public int spaces = 3;
    public Direction attackDirection;
    public int attackRange = 5;
	// Use this for initialization
	void Start ()
    {
        //playerMovement = Direction.UPDOWNLEFTRIGHT;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
