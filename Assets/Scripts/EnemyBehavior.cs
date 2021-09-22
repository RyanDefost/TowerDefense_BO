using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private int takenDamage;

    public int health = 10;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        //speed changeble

        //Make me get damage
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
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
        Debug.Log("Health taken " + takenDamage);

        if (health <= 0)
        {
            Debug.Log("enemy is dead");
            Destroy(gameObject);
        }
    }
}
