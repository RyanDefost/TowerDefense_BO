using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessTower : BaseTowerBehaviour
{
    private EnemyBehavior _EnemyBehavior;

    private void Start()
    {
        _EnemyBehavior = FindObjectOfType<EnemyBehavior>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            print("TEST");
            other.gameObject.GetComponent<EnemyBehavior>().GiveSlowness(false);
                //other.gameObject.GetComponent<EnemyBehavior>()._speed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            other.gameObject.GetComponent<EnemyBehavior>()._speed =
                other.gameObject.GetComponent<EnemyBehavior>()._originalSpeed;

        }
    }
}
