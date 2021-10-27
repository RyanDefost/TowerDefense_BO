using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    //Prefabs
    private EnemySpawner _enemySpawner;

    //WaveInfo UNITY
    public int[] WaveAmount;
    public GameObject[] WaveTarget;

    //TargetCounter (Get/Set)
    private List<GameObject> TargetCounter = new List<GameObject>();
    public List<GameObject> targetCounter { get { return TargetCounter; } set { TargetCounter = value; } }

    private void Start()
    {
        //To use private things form 'EnemySpawner'
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }


    //HOE THE FUCK GEBRUIK IK DIT GOED??
    public struct WaveInfo
    {
        public WaveInfo(int Wave, int[] WaveAmount)
        {
            int Amount = WaveAmount[Wave];

        }
        public WaveInfo(GameObject prefab)
        {
            GameObject Prefab = prefab;

        }

    }

    public void WaveInit()
    {
        //Initiates 'target'
        GameObject target = Instantiate(
            WaveTarget[_enemySpawner._wave], transform.position + new Vector3(0, transform.position.y / 2, 0), transform.rotation);
        
        //CheckLists for Targets (Dead / amount)
        TargetCounter.Add(target);
        _enemySpawner.targetsCount.Add(target);
    }
}
