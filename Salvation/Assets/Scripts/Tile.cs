using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public Building buildingRef;
    public ObstacleType obstacleType;
    bool isStartedTile = true;


    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }
    #region methods
    public void SetOccupied(ObstacleType t)
    {
        obstacleType = t;
    }

    public void SetOccupied(ObstacleType t, Building b)
    {
        obstacleType = t;
        buildingRef = b;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;

    }

    public void StarterTileValue(bool value)
    {
        isStartedTile = value;
    }

    #endregion
    #region bool functions

    public bool IsOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStartedTile;
        }
    }
    #endregion
}

