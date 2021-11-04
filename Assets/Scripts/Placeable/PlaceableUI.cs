using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableUI : MonoBehaviour
{
    [SerializeField] private RectTransform _menuPanel;
    private void Start()
    {
        Show(false);
    }

    public void Show(bool openOrClose)
    {
        _menuPanel.gameObject.SetActive(openOrClose);
    }
}
