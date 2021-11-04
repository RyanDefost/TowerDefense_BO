using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private MoneyManager _moneyManager;

    private int takenDamage;
    public bool isDying = false;

    public int health = 10;

    public float _speed = 2;
    public float _originalSpeed;

    private void Start()
    {
        _originalSpeed = _speed;

        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            takenDamage = collision.gameObject.GetComponent<Bullet_Con>().damage;
            Destroy(collision.gameObject);
            getHit(takenDamage);
        }
    }

    public void getHit(int damageGiven)
    {
        health = health - damageGiven;

        if (health <= 0)
        {
            isDying = true;
            _enemySpawner.targetsCount.Remove(gameObject);
            Destroy(gameObject);
            _moneyManager.AddMoney(1);
        }
    }

    public void GiveSlowness(bool isSlowed)
    {
        if (isSlowed == false)
        {
            print("IK KOM HIER");
            if (_speed == _originalSpeed)
            {
                _speed = _speed / 1.5f;
            }
        }
        else
        {
            _speed = _originalSpeed;
        }
    }
}
