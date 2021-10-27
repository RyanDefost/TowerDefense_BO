using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool _isBuildable;

    public bool GetisBuildable()
    {
        print("INSIDE TILES.cs " + _isBuildable);
        return _isBuildable;
    }

    public Vector3 GetTilePosition()
    {
        return  this.transform.position;
    }
}
