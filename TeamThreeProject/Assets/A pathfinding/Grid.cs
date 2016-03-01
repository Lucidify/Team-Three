using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
    public bool onlyShowPath = false;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public LayerMask unwalkableMask;
    public LayerMask unwalkableMask2;
    public Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;
    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        CreateGrid();

    }

    public void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                bool walkable;
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                if ((Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)) || (Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask2)))
                    walkable = false;
                else
                    walkable = true;
                //bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius,unwalkableMask));
                bool enemy = (Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask2));
                if (Physics.Linecast(worldPoint, worldPoint, unwalkableMask2))
                    print("dfsdfsdfsdf");

                grid[x, y] = new Node(walkable, worldPoint,x,y,enemy);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 pos)
    {
        float percentX = (pos.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (pos.z+ gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = node.m_gridX + x;
                int checkY = node.m_gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    neighbours.Add(grid[checkX, checkY]);
            }
        }
        return neighbours;
    }


    public List<Node> path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x,1, gridWorldSize.y));
        if (onlyShowPath)
        {
            if (path != null)
            {
                foreach (Node n in path)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.05f));
                }
            }
        }
        else
        {
            if (grid != null)
            {
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.m_walkable) ? Color.white : Color.red;
                    if (path != null)
                        if (path.Contains(n))
                            Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.05f));
                }
            }
        }
       
    }
}
