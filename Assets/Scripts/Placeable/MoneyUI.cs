using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateUI(int MoneyNumb)
    {
        _text.text = "Money: " + MoneyNumb;
    }
}
