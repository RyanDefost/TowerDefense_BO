using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceablePrefab : MonoBehaviour
{
    private MoneyManager _moneyManager;
    private PlaceableUI _placeableUI;

    public GameObject BaseTower;
    public GameObject LaserTower;
    public GameObject SlownessTower;

    private Tiles _seclectedTile = null;
    [SerializeField] private LayerMask _layer;

    Vector3 _tilePosition;

    private void Start()
    {
        Setup();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layer))
            {
                Tiles tile = hit.transform.GetComponent<Tiles>();

                if (tile._isBuildable)
                {
                    _seclectedTile = tile;
                    _placeableUI.Show(true);
                }
                else
                {
                    print("NIET BUILDABLE");
                }

            }
        }
    }

    public void PlaceTower(GameObject chosenTower)
    {
        print(chosenTower);
        int Cost = _moneyManager.AmountForTower(chosenTower);


        if (_moneyManager.MoneyCount() >= Cost && _seclectedTile._isBuildable == true)
        {
            GameObject Tower = Instantiate(chosenTower, new Vector3(
                _seclectedTile.transform.position.x, transform.position.y + 1, _seclectedTile.transform.position.z), transform.rotation);
            
            _moneyManager.MoneyMin(Cost);
            _seclectedTile._isBuildable = false;

            _placeableUI.Show(false);
            _seclectedTile = null;


        }
        else
        {
            print("FUCK");
        }
    }


    public void Setup()
    {
        _placeableUI = FindObjectOfType<PlaceableUI>();
        _moneyManager = FindObjectOfType<MoneyManager>();
    }
}
