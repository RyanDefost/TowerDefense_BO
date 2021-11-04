using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private PlayerHealthUI _playerHealthUI;

    public int _maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _playerHealthUI.UpdateUI(_currentHealth);
    }

    public void MinHealth(int damage)
    {
        _currentHealth = _currentHealth - damage;
        _playerHealthUI.UpdateUI(_currentHealth);
    }

}
