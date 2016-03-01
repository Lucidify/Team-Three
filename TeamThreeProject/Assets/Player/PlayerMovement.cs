using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float movement = 0.32f;
    SpriteRenderer sprite;
    public float  moveSpaces = 3;
    bool runonce = false;
    public bool selected = false;
    public GameObject greenTile;
    public GameObject RedTile;
    public GameObject AttackTile;
    GameObject[] objects;
    Vector3 mousepos;
    PlayerStats stats;
    public Button attack;
    public Button move;
    bool attackMove;
    bool clicked = false;
    Battle battle;
    // Use this for initialization
    void Start () {
        battle = GameObject.FindGameObjectWithTag("Battle").GetComponent<Battle>();
        stats = GetComponent<PlayerStats>();
        sprite = GetComponent<SpriteRenderer>();
        attack.gameObject.SetActive(false);
        move.gameObject.SetActive(false);
        clicked = false;
        attackMove = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 test = Camera.main.transform.position;
        test.x = mousepos.x;
        test.y = mousepos.y;
        if (Physics2D.Linecast(mousepos, test, 1 << LayerMask.NameToLayer("Player")))
        {
            if (Input.GetMouseButtonDown(0))
            {
                selected = !selected;
            }
        }

        if (selected)
        {
            attack.gameObject.SetActive(true);
            move.gameObject.SetActive(true);

        }

        if (!selected)
        {
            attack.gameObject.SetActive(false);
            move.gameObject.SetActive(false);
            sprite.color = Color.white;
            objects = GameObject.FindGameObjectsWithTag("Movement");
            if (objects.Length > 0)
            {
                foreach (GameObject obj in objects)
                    Destroy(obj);
            }

        }
        Moveplayer();
        if (attackMove)
            AttackPlayer();
        //ClickPlayer(stats.spaces);
        //Moveplayer();
    }


    void ClickPlayer(int spaces, PlayerStats.Direction dir)
    {
        Vector3 test = Camera.main.transform.position;
        test.x = mousepos.x;
        test.y = mousepos.y;

        if (selected && runonce)
        {
            sprite.color = Color.green;
            Vector3 temp = transform.position;
            int itr = 1;
            int direction = 0;
            int itrX = 1;
            // Check how many directions it can move
            if (dir == PlayerStats.Direction.UP)
                direction = 1;
            else if (dir == PlayerStats.Direction.UPANDDOWN || dir == PlayerStats.Direction.LEFTANDRIGHT)
                direction = 2;
            else if (dir == PlayerStats.Direction.UPDOWNLEFTRIGHT)
                direction = 2;

            for (int i = 1; i <= spaces * direction; i++)
            {
                if (dir == PlayerStats.Direction.UP || dir == PlayerStats.Direction.UPANDDOWN
                    || dir == PlayerStats.Direction.UPDOWNLEFTRIGHT)
                {
                    temp = transform.position;
                    if (i == spaces + 1)
                        itr = 1;
                    Vector3 endPoint = transform.position;
                    if (i > spaces)
                        endPoint.y -= itr * 0.32f;
                    else
                        endPoint.y += itr * 0.32f;
                    if (Physics2D.Linecast(transform.position, endPoint, 1 << LayerMask.NameToLayer("Object")))
                    {
                        // Spawn red tiles so cant move there
                        if (i > spaces)
                            temp.y = transform.position.y - (itr * 0.32f);
                        else
                            temp.y = transform.position.y + (itr * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(RedTile, temp, transform.rotation);
                    }
                    else if (Physics2D.Linecast(transform.position, endPoint, 1 << LayerMask.NameToLayer("Enemy")))
                    {
                        // Spawn red tiles so cant move there
                        if (i > spaces)
                            temp.y = transform.position.y - (itr * 0.32f);
                        else
                            temp.y = transform.position.y + (itr * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(AttackTile, temp, transform.rotation);
                    }
                    else
                    {
                        // Spawn green tiles to move there

                        // front

                        if (i > spaces)
                            temp.y = transform.position.y - (itr * 0.32f);
                        else
                            temp.y = transform.position.y + (itr * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(greenTile, temp, transform.rotation);
                    }
                    itr++;
                }
                if (dir == PlayerStats.Direction.LEFTANDRIGHT || dir == PlayerStats.Direction.UPDOWNLEFTRIGHT)
                {

                    temp = transform.position;
                    if (i == spaces + 1)
                        itrX = 1;
                    Vector3 endPoint = transform.position;
                    if (i > spaces)
                        endPoint.x -= itrX * 0.32f;
                    else
                        endPoint.x += itrX * 0.32f;
                    if (Physics2D.Linecast(transform.position, endPoint, 1 << LayerMask.NameToLayer("Object")))
                    {
                        // Spawn red tiles so cant move there
                        if (i > spaces)
                            temp.x = transform.position.x - (itrX * 0.32f);
                        else
                            temp.x = transform.position.x + (itrX * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(RedTile, temp, transform.rotation);
                    }
                    else if (Physics2D.Linecast(transform.position, endPoint, 1 << LayerMask.NameToLayer("Enemy")))
                    {
                        // Spawn red tiles so cant move there
                        if (i > spaces)
                            temp.x = transform.position.x - (itrX * 0.32f);
                        else
                            temp.x = transform.position.x + (itrX * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(AttackTile, temp, transform.rotation);
                    }
                    else
                    {
                        // front
                        if (i > spaces)
                            temp.x = transform.position.x - (itrX * 0.32f);
                        else
                            temp.x = transform.position.x + (itrX * 0.32f);
                        if (Physics2D.Linecast(temp, temp, 1 << LayerMask.NameToLayer("Floor")))
                            Instantiate(greenTile, temp, transform.rotation);
                    }
                    itrX++;
                }

            }

            runonce = false;
        }
    }
    void AttackPlayer()
    {
        if (Physics2D.Linecast(mousepos, new Vector3(mousepos.x, mousepos.y, 0), 1 << LayerMask.NameToLayer("Enemy")))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit;
                hit = Physics2D.Linecast(mousepos, new Vector3(mousepos.x, mousepos.y, 0), 1 << LayerMask.NameToLayer("Enemy"));
                hit.collider.gameObject.GetComponent<EnemyStats>().health -= 50;
                selected = false;
                clicked = false;
                attackMove = false;
                battle.playerTurn = false;
            }
        }
    }
    void Moveplayer()
    {
        if (selected)
        {
            if (Physics2D.Linecast(mousepos, new Vector3(mousepos.x, mousepos.y,0), 1 << LayerMask.NameToLayer("Movement")))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // check to see where moving 
                    // Foward
                    float distanceY = mousepos.y - transform.position.y;
                    float distanceX = mousepos.x - transform.position.x;
                    int movedspaces = 0;
                    if (distanceX > 0.16f)
                    {
                        movedspaces = (int)((distanceX + 0.16f) / 0.32f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + (movedspaces * 0.32f), transform.position.y, transform.position.z), 2);
                        selected = false;
                        clicked = false;
                        battle.playerTurn = false;
                    }
                    if (distanceX < -0.16f)
                    {
                        movedspaces = (int)((distanceX - 0.16f) / 0.32f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + (movedspaces * 0.32f), transform.position.y, transform.position.z), 2);
                        selected = false;
                        clicked = false;
                        battle.playerTurn = false;
                    }
                    else if (distanceY > 0.16f)
                    {
                        movedspaces = (int)((distanceY + 0.16f) / 0.32f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + (movedspaces * 0.32f), transform.position.z), 2);
                        selected = false;
                        clicked = false;
                        battle.playerTurn = false;
                    }
                    else if (distanceY < -0.16f)
                    {
                        movedspaces = (int)((distanceY - 0.16f) / 0.32f);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + (movedspaces * 0.32f), transform.position.z), 2);
                        selected = false;
                        clicked = false;
                        battle.playerTurn = false;
                    }
                }

            }
        }
    }

    public void Attack()
    {
        if (selected && !clicked )
        {
            clicked = true;
            runonce = true;
            attackMove = true;
            ClickPlayer(stats.attackRange, stats.attackDirection);
            
        }

    }
    public void Move()
    {
        if (selected && !clicked)
        {
            clicked = true;
            runonce = true;
            ClickPlayer(stats.spaces, stats.playerMovement);
            

        }

    }
}
