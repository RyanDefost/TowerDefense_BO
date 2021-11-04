using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : BaseTowerBehaviour
{
    //Shoots laser that go's thru enemy's and damages all of them a bit;

    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
    }

    private void Update()
    {
        GetTargetShoot();

        if (enterView.Count > 0 && enterView[0] != null)
        {
            line.enabled = true;
            Vector3 NewPos = new Vector3(enterView[0].transform.position.x, enterView[0].transform.position.y + 1, enterView[0].transform.position.z);
            line.SetPosition(1, NewPos);
            line.SetPosition(0, BulletSpawner.transform.position);
        }
        else
        {
            line.enabled = false;
        }
    }

    public override void shoot()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit);

        if (hit.collider.gameObject.tag == "targetBody")
        {
            hit.collider.gameObject.GetComponentInParent<EnemyBehavior>().getHit(1);
        }
    }
}
