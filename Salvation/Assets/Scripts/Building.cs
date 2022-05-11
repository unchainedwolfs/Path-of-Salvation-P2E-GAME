using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Building
{
    //The ID of exact building
    public int buildingID;

    // X -axis to the grid
    public int width = 0;

    // Y -axis to the grid
    public int length = 0;

  //Type of the Building
    public ResourceType resourceType = ResourceType.None;

    public enum ResourceType
    {
        None,
        Standard,
        Premium
    }
}
