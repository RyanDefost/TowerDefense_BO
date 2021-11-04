using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    //Prefabs
    private EnemySpawner _enemySpawner;

    //WaveInfo UNITY
    [System.Serializable]
    public class WaveInfo
    {
        public int Amount;
        public GameObject _Prefabs;
    }
    public WaveInfo[] _waveInfo;

    //TargetCounter (Get/Set)
    private List<GameObject> TargetCounter = new List<GameObject>();
    public List<GameObject> targetCounter { get { return TargetCounter; } set { TargetCounter = value; } }

    private void Start()
    {
        //To use private things form 'EnemySpawner'
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void WaveInit()
    {
        //Initiates 'target'
        GameObject target = Instantiate(
            _waveInfo[_enemySpawner._wave]._Prefabs, transform.position + new Vector3(0, transform.position.y / 2, 0), transform.rotation);
        
        //CheckLists for Targets (Dead / amount)
        TargetCounter.Add(target);
        _enemySpawner.targetsCount.Add(target);

        if (_waveInfo[1].Amount == 1)
        {

        }
    }
}
