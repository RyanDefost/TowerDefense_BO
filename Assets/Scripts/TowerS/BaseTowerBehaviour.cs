using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerBehaviour : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject BulletSpawner;

    public int damage = 1;

    public float bulletRange = 5f;

    public float fireRate = 0.5f;
    private float NextFire = 0.0f;

    private List<GameObject> EnterView = new List<GameObject>();
    public List<GameObject> enterView { get { return EnterView; } set { EnterView = value; } }

    // Update is called once per frame
    void Update()
    {
        GetTargetShoot();
    }

    public virtual void shoot()
    {
        GameObject bullet = Instantiate(bulletObject, BulletSpawner.transform.position , transform.rotation);

        bullet.GetComponent<Bullet_Con>().damage = damage;   
        Destroy(bullet, bulletRange);
    }

    public virtual void GetTargetShoot()
    {
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
