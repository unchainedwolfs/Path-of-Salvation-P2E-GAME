using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Builder")]

    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Space(8)]
    //This is the grid that directry stores all the information
    public TileObject[,] tileGrid = new TileObject[0, 0];

    [Header("Resources")]

    [Space(8)]

    public GameObject woodPrefap;
    public GameObject rockPrefap;
    public Transform resourcesHolder;

    [Range(0, 1)]
    public float obstacleChange = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]


    //debug method (the selected building)
    public BuildingObject buildingToPlace;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Directry spawns a tile
                TileObject spawnedTile =    SpawnTile(x * tileSize, z * tileSize);

                //Sets the TileObject world space data
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;


                //Checks whenever er can spawn an obstage inside a tile. Using bounds parameters 
                if (x< xBounds || z < zBounds || z>=(levelLength- zBounds) || x>= (levelWidth- xBounds))
                {
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChange;
                    if (spawnObstacle)
                    {
                       spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);
                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                        tmpObstacle.SetTileReference(spawnedTile);
                    }
                }
                //Adds  the spawn tileobject inside the list.
                visualGrid.Add(spawnedTile);
            }
        }

        CreateGrid(visualGrid);
    }

    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);
        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile" + xPos + "_" + zPos;
        return tmpTile.GetComponent<TileObject>();


    }

    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {
        bool isWood = Random.value <= 0.5f;
        GameObject spawnedObstacle = null;
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefap);
            spawnedObstacle.name = "Wood " + xPos + "_" + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefap);
            spawnedObstacle.name = "Stone " + xPos + "_" + zPos;
        }

        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
       
    }
    //Grid for buildings
    public void CreateGrid(List<TileObject> refViualGrid)
    {
        //Set the size of the tile grid
        tileGrid = new TileObject [levelWidth, levelLength];

        // Interates through the tile grid
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                tileGrid[x, z] = refViualGrid.Find(v => v.xPos == x && v.zPos == z);
                Debug.Log(tileGrid[x, z].gameObject.name);
            }
        }
    }

    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        GameObject spawedBuilding = Instantiate(building.gameObject);
        float sumX = 0;
        float sumZ = 0;

        // Vector3 position = new Vector3(tile.xPos, tileEndHeight, tile.zPos);

        for (int i = 0; i < tiles.Count; i++)
        {
            sumX += tiles[i].xPos;
            sumZ += tiles[i].zPos;
            tiles[i].data.SetOccupied(Tile.ObstacleType.Building);
            Debug.Log("placed building in " + tiles[i].xPos + " - " + tiles[i].zPos);
          
        }
        //set correct possition
        Vector3 position = new Vector3((sumX/tiles.Count), tileEndHeight + building.data.yPadding,(sumZ/tiles.Count));

        spawedBuilding.transform.position = position;
    }
}
