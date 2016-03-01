using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerPathMovement : MonoBehaviour
{
    public GameObject tile;
    public GameObject redTile;
    public int moveSpaces = 5;
    public Button up, down, left, right;
    public bool attackUp, attackLeft, attackRight, attackDown;
    Enemies enemies;
    GameObject[] objects;
    public BattlePath battle;
    int movesLeft = 0;
    public int moves = 0;
    bool runonce = false;
    Grid grid;
    bool move;
    bool attack;
    // Use this for initialization
    void Start()
    {

        up.gameObject.SetActive(false);
        down.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (battle.playerTurn)
        {
            Camera.main.transform.position = new Vector3(transform.position.x, 32, transform.position.z);
            if (Camera.main.transform.position.x <= -0.54f)
                Camera.main.transform.position = new Vector3(-0.54f, 32, Camera.main.transform.position.z);
            if (Camera.main.transform.position.x >= 0.54f)
                Camera.main.transform.position = new Vector3(0.54f, 32, Camera.main.transform.position.z);
            if (Camera.main.transform.position.z <= -1.53)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, -1.53f);
            if (Camera.main.transform.position.z >= 1.53f)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, 1.53f);
        }
        moves = moveSpaces - movesLeft;
        if (moves == 0 && runonce)
        {
            runonce = false;
            battle.playerTurn = false;
            up.gameObject.SetActive(false);
            down.gameObject.SetActive(false);
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
        }
            
    }

    public void Attack()
    {
        Vector3 fwd = new Vector3(0, 0, 1);
        RaycastHit hit;
        Physics.Raycast(transform.position,fwd,out hit,0.32f);
        if (hit.collider.tag == "Enemy")
        {
            hit.collider.gameObject.GetComponent<EnemyAttack>().enemyHealth -= gameObject.GetComponent<PlayerPathStats>().attack; 
        }
        
       
    }
    public void PlayerMove()
    {
        if (battle.playerTurn)
        {
            move = true;
            attack = false;
            attackDown = false;
            attackLeft = false;
            attackRight = false;
            attackUp = false;
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            moves = moveSpaces;
            movesLeft = 0;
            MovePlayer();
            runonce = true;

        }




    }

    public void MoveUp()
    {
        if (move)
        {
            print("Move Up");
            grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.32f);
            Node up = grid.NodeFromWorldPosition(newpos);
            if (up.m_walkable && up.m_gridY < 19)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.32f), 1);
                objects = GameObject.FindGameObjectsWithTag("Movement");
                if (objects.Length > 0)
                {
                    foreach (GameObject obj in objects)
                        Destroy(obj);
                }
                movesLeft++;
                moves = moveSpaces - movesLeft;
                MovePlayer();
            }
            
        

        }
        

    }
    public void MoveDown()
    {
        grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.32f);
        Node up = grid.NodeFromWorldPosition(newpos);
        if (up.m_walkable && up.m_gridY >0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.32f), 1);
            objects = GameObject.FindGameObjectsWithTag("Movement");
            if (objects.Length > 0)
            {
                foreach (GameObject obj in objects)
                    Destroy(obj);
            }
            movesLeft++;
            moves = moveSpaces - movesLeft;
            MovePlayer();
        }
        
    }
    public void MoveLeft()
    {
        grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        Vector3 newpos = new Vector3(transform.position.x - 0.32f, transform.position.y, transform.position.z);
        Node up = grid.NodeFromWorldPosition(newpos);
        if (up.m_walkable && up.m_gridX > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 0.32f, transform.position.y, transform.position.z), 1);
            objects = GameObject.FindGameObjectsWithTag("Movement");
            if (objects.Length > 0)
            {
                foreach (GameObject obj in objects)
                    Destroy(obj);
            }
            movesLeft++;
            moves = moveSpaces - movesLeft;
            MovePlayer();
        }
        
       
    }
    public void MoveRight()
    {
        grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        Vector3 newpos = new Vector3(transform.position.x + 0.32f, transform.position.y, transform.position.z);
        Node up = grid.NodeFromWorldPosition(newpos);
        if (up.m_walkable && up.m_gridX < 19)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 0.32f, transform.position.y, transform.position.z), 1);
            objects = GameObject.FindGameObjectsWithTag("Movement");
            if (objects.Length > 0)
            {
                foreach (GameObject obj in objects)
                    Destroy(obj);
            }
            //Vector3 cam = Camera.main.gameObject.transform.position;
            //Camera.main.gameObject.transform.position = new Vector3(cam.x + 0.1f, cam.y, cam.z);
            movesLeft++;
            moves = moveSpaces - movesLeft;
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        grid.path = null;
        grid.grid = null;
        grid.CreateGrid();
        print("This hits");
        // Check left -0.32;
        for (int i = 1; i <= moves; i++)
        {
            Vector3 moveLeft = new Vector3(transform.position.x - (i * 0.32f), transform.position.y, transform.position.z);
            Vector3 moveUp = new Vector3(transform.position.x, transform.position.y, transform.position.z + (i * 0.32f));
            Node left = grid.NodeFromWorldPosition(moveLeft);
            Node up = grid.NodeFromWorldPosition(moveUp);
            if (left.m_walkable)
            {

                Instantiate(tile, moveLeft, transform.rotation);
            }
            else 
            {
                if (left.enemy)
                    attackLeft = true;
                Instantiate(redTile, moveLeft, transform.rotation);
            }

            if (up.m_walkable)
            {
                Instantiate(tile, moveUp, transform.rotation);
            }
            else
            {
                if (up.enemy)
                    attackUp = true;
                Instantiate(redTile, moveUp, transform.rotation);
            }

            Vector3 moveRight = new Vector3(transform.position.x + (i * 0.32f), transform.position.y, transform.position.z);
            Vector3 moveDown = new Vector3(transform.position.x, transform.position.y, transform.position.z - (i * 0.32f));
            Node right = grid.NodeFromWorldPosition(moveRight);
            Node down = grid.NodeFromWorldPosition(moveDown);
            if (right.m_walkable)
            {
                Instantiate(tile, moveRight, transform.rotation);
            }
            else
            {
                if (right.enemy)
                    attackRight = true;
                Instantiate(redTile, moveRight, transform.rotation);
            }
            if (down.m_walkable)
            {
                Instantiate(tile, moveDown, transform.rotation);
            }
            else
            {
                if (down.enemy)
                    attackDown = true;
                Instantiate(redTile, moveDown, transform.rotation);
            }
        }
    }
}
