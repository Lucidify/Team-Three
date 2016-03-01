using UnityEngine;
using System.Collections;

public class UnitMove : MonoBehaviour {
    public Transform target;
    public Grid grid;
    int i = 0;
    public bool first = true;
    public bool second = true;
    int waypoint;
    public bool moveOn = false;
    public bool canAttack = false;
    LayerMask layer;
    public pathfinding pathfinder;
    public GameObject tile;
    GameObject[] objects;
    EnemyPathFindingStats stats;
    bool firstrun = true;
    public bool runonce = true;
    // Use this for initialization
    void Awake()
    {
        stats = GetComponent<EnemyPathFindingStats>();
        layer = LayerMask.NameToLayer("Default");
        gameObject.layer = layer;
    }
    public void MoveObject()
    {

        //pathfinder.FindPath(transform.position, target.position);
        if (first)
        {
            if (firstrun)
            {
                layer = LayerMask.NameToLayer("Default");
                gameObject.layer = layer;
                grid.path = null;
                grid.grid = null;
                grid.CreateGrid();
                gameObject.AddComponent<pathfinding>();
                pathfinder = GetComponent<pathfinding>();
                if (runonce)
                    pathfinder.FindPath(target.position, transform.position);
                if (grid.path.Count <=  2)
                {
                    canAttack = true;
                }
                else
                {
                    canAttack = false;
                }
                pathfinder.target = transform;
                pathfinder.seeker = target;
                firstrun = false;
                runonce = false;
                first = false;
            }
            else
            {
                layer = LayerMask.NameToLayer("Default");
                gameObject.layer = layer;
                grid.path = null;
                grid.grid = null;
                grid.CreateGrid();
                pathfinder = GetComponent<pathfinding>();
                pathfinder.target = transform;
                pathfinder.seeker = target;
                if (runonce)
                    pathfinder.FindPath(target.position, transform.position);
                if (grid.path.Count <= 2)
                {
                    canAttack = true;
                }
                else
                {
                    canAttack = false;
                }
                firstrun = false;
                runonce = false;
                first = false;
            }
            
        }
            if(second &&grid.path != null)
            {
                HighlightPath();
                waypoint = grid.path.Count;
                StopCoroutine("Move");
                StartCoroutine("Move");
                second = false;
            }
    }

    void HighlightPath()
    {
        foreach (Node n in grid.path)
        {
            Instantiate(tile, n.worldPosition, transform.rotation);
        }
    }

    IEnumerator Move()
    {
        Vector3 currentWaypoint = grid.path[grid.path.Count - 1].worldPosition;
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                waypoint--;
                if (waypoint == grid.path.Count - 1 - (stats.moveSpaces + 1) || waypoint == -1 )
                {
                    moveOn = true;
                    layer = LayerMask.NameToLayer("Enemy");
                    objects = GameObject.FindGameObjectsWithTag("Movement");
                    if (objects.Length > 0)
                    {
                        foreach (GameObject obj in objects)
                            Destroy(obj);
                    }
                    gameObject.layer = layer;
                    yield break;
                }
                currentWaypoint = grid.path[waypoint].worldPosition;
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, 0.01f);
            Camera.main.transform.position = new Vector3(transform.position.x, 32, transform.position.z);
            if (Camera.main.transform.position.x <= -0.54f)
                Camera.main.transform.position = new Vector3(-0.54f, 32, Camera.main.transform.position.z);
            if (Camera.main.transform.position.x >= 0.54f)
                Camera.main.transform.position = new Vector3(0.54f, 32, Camera.main.transform.position.z);
            if (Camera.main.transform.position.z <= -1.53)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, -1.53f);
            if (Camera.main.transform.position.z >= 1.53f)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, 1.53f);
            yield return null;
        }
        
    }
}
