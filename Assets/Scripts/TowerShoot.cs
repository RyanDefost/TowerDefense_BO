using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject BulletSpawner;

    public int damage = 1;

    public float bulletRange = 5f;

    public float fireRate = 0.5f;
    private float NextFire = 0.0f;

    List <GameObject> EnterView = new List <GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }


        // if the Target is "dead" it will not try and look for it
        if (EnterView.Count > 0 && EnterView[0] != null)
            {
                // The tower will look at the first Target in the array
                transform.LookAt(EnterView[0].transform, Vector3.up);
                
                if (Time.time > NextFire)
                {
                    NextFire = Time.time + fireRate;
                    shoot();
                }
            }

        if (EnterView.Count > 0 && EnterView[0] == null)
            {
                EnterView.Remove(EnterView[0]);
            }

    }

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletObject, BulletSpawner.transform.position , transform.rotation);
        bullet.GetComponent<Bullet_Con>().damage = damage;   
        Destroy(bullet, bulletRange);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            EnterView.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            //When it leaves the range it will look at the next one
            EnterView.Remove(other.gameObject);
        }

    }


}
