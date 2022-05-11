using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]

    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;

    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                SpawnTile(x * tileSize, z * tileSize);
            }
        }
    }

    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);
        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);
        return tmpTile.GetComponent<TileObject>();
    }
}
