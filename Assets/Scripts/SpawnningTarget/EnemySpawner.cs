using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Waves script
    private List<GameObject> TargetsCount = new List<GameObject>();
    public List<GameObject> targetsCount { get { return TargetsCount; } set { TargetsCount = value; } }

    private Waves _waves;

    //WaveState
    public int _wave = 0;
    private bool WaveStart = true;
    private bool WaveEnded = false;

    //Timer
    private float SpawnRate = .7f;
    private float NextTimer = 0.0f;

    private void Start()
    {
        _waves = FindObjectOfType<Waves>();
    }

    private void Update()
    {
        //WAVESTART
        if (Time.time > NextTimer && WaveStart)
        {
            NextTimer = Time.time + SpawnRate;
            _waves.WaveInit();

            if (_waves.targetCounter.Count == _waves._waveInfo[_wave].Amount)
            {
                _waves.targetCounter.Clear();
                WaveStart = false;
                WaveEnded = true;
            }
        }

        //WAVEENDED
        if (WaveEnded && TargetsCount.Count == 0)
        {
            WaveEnded = false;
            if (_wave != _waves._waveInfo.Length - 1)
            {
                _wave = _wave + 1;
            }
            WaveStart = true;
            if (_wave > 10)
            {
                SpawnRate = .5f;
            }
        }
    }
}
