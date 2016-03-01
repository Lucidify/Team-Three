using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class pathfinding : MonoBehaviour {
    public Transform seeker;
    public Transform target;
    Grid grid;
    bool run = true;
    public void Start()
    {
        //grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        //FindPath(seeker.position, target.position);
        //FindPath(seeker.position, target.position);
    }

    void Update()
    {
        //if (run && seeker != null && target != null)
        //{
           
        //    run = false;
        //}

    }
    public void FindPath(Vector3 start, Vector3 targetPos)
    {
        grid = GameObject.FindGameObjectWithTag("A*").GetComponent<Grid>();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Node startNode = grid.NodeFromWorldPosition(start);
        Node targetNode = grid.NodeFromWorldPosition(targetPos);
        List<Node> openSet = new List<Node>();
        HashSet<Node> closeSet = new HashSet<Node>();
        openSet.Add(startNode);
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 0; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    currentNode = openSet[i];

            }
            openSet.Remove(currentNode);
            closeSet.Add(currentNode);
            if (currentNode == targetNode)
            {
                sw.Stop();
                print("Path Found " + sw.ElapsedMilliseconds + "ms");
                RetracePath(startNode, targetNode);
                return;
            }
                
            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.m_walkable || closeSet.Contains(neighbour))
                    continue;
                int newMovementCost = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCost < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCost;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        grid.path = path;
    }
    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.m_gridX - nodeB.m_gridX);
        int distY = Mathf.Abs(nodeA.m_gridY - nodeB.m_gridY);

        if (distX > distY)
            return 14 * distX + 10 * (distX - distY);
        return 14 * distX + 10 * (distY - distX);
    }

}
