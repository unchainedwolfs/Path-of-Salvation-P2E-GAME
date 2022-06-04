using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public Tile data;

    [Header("World Tile Data")]
    [Space(8)]

    //Position of the tile
    public int xPos = 0;
    public int zPos = 0;

    private void OnMouseDown()
    {
        Debug.Log("Click on " + gameObject.name);

        if (!data.IsOccupied)
        {
            //flag if is able to place a building.
            bool canPlaceBuildingHere = true;

            if (GameManager.Instance.buildingToPlace != null)
            {
                List<TileObject> iteratedTiles = new List<TileObject>();

                for (int x = xPos; x < xPos+GameManager.Instance.buildingToPlace.data.width; x++)
                {

                    if (canPlaceBuildingHere)
                    {
                        for (int z = zPos; z < zPos + GameManager.Instance.buildingToPlace.data.length; z++)
                        {

                            iteratedTiles.Add(GameManager.Instance.tileGrid[x, z]);
                            if (GameManager.Instance.tileGrid[x, z].data.IsOccupied)
                            {
                                canPlaceBuildingHere = false;
                                break;
                            }
                           
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);

                }
                else
                {
                    Debug.Log("Could not place building");
                }
    
            }
            else
            {
                Debug.Log("building to place is null");
            }
        }

        
    }
}
