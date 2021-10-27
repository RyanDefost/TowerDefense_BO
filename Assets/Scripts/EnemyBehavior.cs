using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySpawner _enemySpawner;

    private int takenDamage;
    public bool isDying = false;

    public int health = 10;
    public int speed;

    private void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            takenDamage = collision.gameObject.GetComponent<Bullet_Con>().damage;
            Destroy(collision.gameObject);
            getHit();
        }
    }

    public void getHit()
    {
        //int takenDamage = GetComponent<Bullet_Con>().damage;

        health = health - takenDamage;
        //Debug.Log("Health taken " + takenDamage);

        if (health <= 0)
        {
            isDying = true;
            //Debug.Log("enemy is dead");
            _enemySpawner.targetsCount.Remove(gameObject);
            Destroy(gameObject);
            //print("After Removing one " + _enemySpawner.targetsCount.Count);
        }
    }
}
