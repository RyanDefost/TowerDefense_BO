using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private MoneyUI _moneyUI;
    private PlaceablePrefab _placeablePrefab;
    public int MoneyAmount = 90;

    // Start is called before the first frame update
    void Start()
    {
        _placeablePrefab = FindObjectOfType<PlaceablePrefab>();

        _moneyUI.UpdateUI(MoneyAmount);
    }

    public void AddMoney(int amount)
    {
        MoneyAmount = MoneyAmount + amount;
        _moneyUI.UpdateUI(MoneyAmount);
    }

    public int MoneyCount()
    {
        return MoneyAmount;
    }

    public int AmountForTower(GameObject tower)
    {
        int Amount = 30;
        if (tower == _placeablePrefab.BaseTower)
        {
            Amount = 30;
        }
        if (tower == _placeablePrefab.LaserTower)
        {
            Amount = 40;
        }
        if (tower == _placeablePrefab.SlownessTower)
        {
            Amount = 20;
        }
        return Amount;
    }
    public void MoneyMin(int amount)
    {
        MoneyAmount = MoneyAmount - amount;
        _moneyUI.UpdateUI(MoneyAmount);
    }
}
