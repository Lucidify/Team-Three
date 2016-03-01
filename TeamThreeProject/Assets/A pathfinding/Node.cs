using UnityEngine;
using System.Collections;
using System;

public class Node : IheapItem<Node>{
    public bool m_walkable;
    public Vector3 worldPosition;
    public int gCost;
    public int hCost;
    public int m_gridX;
    public int m_gridY;
    public Node parent;
    public bool isEnemy = false;
    public bool enemy;
    int heapIndex;
    public Node(bool walkable, Vector3 worldPos,int gridX,int gridY,bool enemys)
    {
        m_walkable = walkable;
        worldPosition = worldPos;
        m_gridX = gridX;
        m_gridY = gridY;
        enemy = enemys;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex ;
        }

        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node other)
    {
        int compare = fCost.CompareTo(other.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(other.hCost);
        }
        return -compare;
    }
}
