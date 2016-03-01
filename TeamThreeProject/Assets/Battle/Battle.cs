using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle : MonoBehaviour {
    public int enemySize;
    //public Enemies enemies;
    public bool playerTurn = true;
    List<int> moves;
    List<int> movesLeft;
    List<int> movesRight;
    List<int> movesUp;
    List<int> move;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool moveUp;
    bool nextEnemy = true;
    float timer;
    public timer time;
    int i = 0;
    enum direction
    {
        up,down,left,right
    }
    // Use this for initialization
    void Start () {
        playerTurn = true;
        moves = new List<int>();
        move = new List<int>();
        movesLeft = new List<int>();
        movesRight = new List<int>();
        movesUp = new List<int>();
        //enemySize = enemies.enemies.Count;
        timer = 0;
    }
    void Awake()
    {
        Vector3 end = transform.position;
    }
	// Update is called once per frame
	void Update () {
        //if (enemySize == 0)
        //    Application.LoadLevel(2);
        //if (!playerTurn)
        //{
        //    for (i = 0; i < enemySize;)
        //    {
        //        if (nextEnemy)
        //        {
        //               //nextEnemy = false;
        //        }
        //    }
            
        //    playerTurn = true;
        //}
	}
    void PossibleMoves(direction dir)
    {
        int spaces = gameObject.GetComponent<PlayerStats>().spaces;
        for (int j = 1; j <= spaces; j++)
        {
            
            Vector3 end = transform.position;
            if (dir == direction.down)
                end.y -= (j * 0.32f);
            else if (dir == direction.up)
                end.y += (j * 0.32f);
            else if (dir == direction.left)
                end.x -= (j * 0.32f);
            else if (dir == direction.right)
                end.x += (j * 0.32f);
            // check down
            if (!Physics2D.Linecast(transform.position, end, 1 << LayerMask.NameToLayer("Object")) &&
                !Physics2D.Linecast(end, end, 1 << LayerMask.NameToLayer("Enemy")) &&
                 !Physics2D.Linecast(transform.position, end, 1 << LayerMask.NameToLayer("Player"))
                && Physics2D.Linecast(end, end, 1 << LayerMask.NameToLayer("Floor")))
            {
                if (dir == direction.down)
                    moves.Add(j);
                else if (dir == direction.up)
                    movesUp.Add(j);
                else if (dir == direction.left)
                    movesLeft.Add(j);
                else if (dir == direction.right)
                    movesRight.Add(j);
            }
        }
        // Check how many spaces it can move
        if (dir == direction.down)
            Debug.Log(moves.Count);
        if (dir == direction.up)
            Debug.Log(movesUp.Count);
        if (dir == direction.left)
            Debug.Log(movesLeft.Count);
        if (dir == direction.right)
            Debug.Log(movesRight.Count);
    }

    void Move(int i)
    {
        int move = 0;
        while (true)
        {
            int rand = Random.Range(1, 4);
            if (rand == 1)
            {
                if (moves.Count > 0)
                {
                    move = Random.Range(1, moves.Count);
                    Debug.Log("Move downwards " + move + " spaces");
                    Vector3 pos = transform.position;
                    transform.position = new Vector3(pos.x, pos.y - (move * 0.32f), pos.z);
                    break;
                }
            }
            else if (rand == 2)
            {
                if (movesUp.Count > 0)
                {
                    move = Random.Range(1, movesUp.Count);
                    Debug.Log("Move up " + move + " spaces");
                    Vector3 pos = transform.position;
                    transform.position = new Vector3(pos.x, pos.y + (move * 0.32f), pos.z);
                    break;
                }
            }
            else if (rand == 3)
            {
                if (movesLeft.Count > 0)
                {
                    move = Random.Range(1, movesLeft.Count);
                    Debug.Log("Move left " + move + " spaces");
                    Vector3 pos = transform.position;
                    transform.position = new Vector3(pos.x - (move * 0.32f), pos.y, pos.z);
                    break;
                }
            }
            else if (rand == 4)
            {
                if (movesRight.Count > 0)
                {
                    move = Random.Range(1, movesRight.Count);
                    Debug.Log("Move right " + move + " spaces");
                    Vector3 pos = transform.position;
                    transform.position = new Vector3(pos.x + (move * 0.32f), pos.y, pos.z);
                    break;
                }
            }
            if (movesRight.Count == 0 && movesLeft.Count == 0 && movesUp.Count == 0 && moves.Count == 0)
                break;
        }
    }

    public void EnemyMove()
    {
        if (PlayerStats.Direction.UPDOWNLEFTRIGHT == gameObject.GetComponent<PlayerStats>().playerMovement)
        {
            PossibleMoves(direction.down);
            PossibleMoves(direction.left);
            PossibleMoves(direction.right);
            PossibleMoves(direction.up);
            Move(i);
        }
        else if (PlayerStats.Direction.UP == gameObject.GetComponent<PlayerStats>().playerMovement)
        {
            PossibleMoves(direction.up);
            Move(i);
        }
        else if (PlayerStats.Direction.UPANDDOWN == gameObject.GetComponent<PlayerStats>().playerMovement)
        {
            PossibleMoves(direction.up);
            PossibleMoves(direction.down);
            Move(i);
        }
        else
        {
            PossibleMoves(direction.left);
            PossibleMoves(direction.right);
            Move(i);
        }
        moves = new List<int>();
        move = new List<int>();
        movesLeft = new List<int>();
        movesRight = new List<int>();
        movesUp = new List<int>();

    }
}
