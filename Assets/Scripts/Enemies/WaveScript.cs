using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private int _waveNum = 0;
    [SerializeField] private List<Transform> _enemySpawnPoints;
    private int _chosenSpawnPointNum = -1;
    private float _counter = 0;
    [SerializeField] private float _spawnTime = 3f;
    [SerializeField] private GameObject _basicEnemy;
    int _lastLaneSelected = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime;
        if (_counter >= _spawnTime)
        {
            _counter = 0;
            SpawnBasicEnemy();
        }
    }
    void SpawnBasicEnemy()
    {
        do //make it so it cant spawn in the same lane 2 times in a row
        {
            _chosenSpawnPointNum = Random.Range(0, _enemySpawnPoints.Count);

        } while (_chosenSpawnPointNum == _lastLaneSelected);
        _lastLaneSelected = _chosenSpawnPointNum;
        Instantiate(_basicEnemy, _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
    }
}
