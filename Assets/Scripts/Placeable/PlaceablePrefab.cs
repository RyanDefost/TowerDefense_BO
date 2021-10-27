using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceablePrefab : MonoBehaviour
{
    private Tiles _tiles;

    public GameObject BaseTower;
    bool _isBuildable = false;
    Vector3 _tilePosition;

    //click Button to set "Holding tower" true
    //if "Holding tower" == true

    //Tiles can be clicked.
    //Check if Tile == Buildeble.
    //Get posistion BuildebleTile.

    //Instanciate prefab on posistion.BuildebleTile
    //then "Holding tower" == false

    private void Start()
    {
        Setup();
    }

    private void OnMouseDown()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.layer == 8)
            {
                //Setup
                _isBuildable = hit.collider.gameObject.GetComponent<Tiles>().GetisBuildable();
                Vector3 _tilePosition = hit.collider.gameObject.GetComponent<Tiles>().GetTilePosition();

                print(_isBuildable);

                PlaceTower(_tilePosition);
                hit.collider.gameObject.GetComponent<Tiles>()._isBuildable = false;
            }
        }
    }

    public void PlaceTower(Vector3 Pos)
    {
        if (_isBuildable == true)
        {
            GameObject Tower = Instantiate(BaseTower,new Vector3(Pos.x, transform.position.y + 1, Pos.z), transform.rotation);

        }
    }

    public void Setup()
    {
        _tiles = FindObjectOfType<Tiles>();
    }
}
