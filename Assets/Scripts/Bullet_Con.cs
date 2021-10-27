using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Con : MonoBehaviour
{
    public int damage;
    public Rigidbody rb;
    public int speed = 5;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

}
