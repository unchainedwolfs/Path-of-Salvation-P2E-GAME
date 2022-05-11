using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public Building buildingRef;
    public bool occupied;
    public ObstacleType obstacleType;


    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void SetOccupied(ObstacleType t)
    {
        occupied = true;
        obstacleType = t;
    }

    public void SetOccupied(ObstacleType t, Building b)
    {
        occupied = true;
        obstacleType = t;
        buildingRef = b;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
        occupied = false;

    }
}

