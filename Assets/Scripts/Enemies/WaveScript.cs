using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private int _waveNum = 0;
    [SerializeField] private List<Transform> _enemySpawnPoints;
    [SerializeField] List<GameObject> _fences;
    private int _chosenSpawnPointNum = -1;
    private float _counter = 0;
    [SerializeField] private float _spawnTime = 5f;
    [SerializeField] private GameObject _basicEnemy;
    [SerializeField] private GameObject _batEnemy;
    [SerializeField] private GameObject _tankEnemy;
    [SerializeField] private GameObject _dracula;



    [SerializeField] private DisplayTextScript _displayText;
    private List<GameObject> _wave1;
    private List<GameObject> _wave2;
    private List<GameObject> _wave3;
    private List<GameObject> _wave4;
    private List<GameObject> _wave5;


    [SerializeField] private DraculaHealthBarScript _draculaHealthbar;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _storyPanel;



    int _lastLaneSelected = -1;
    // Start is called before the first frame update
    void Start()
    {
        //StartWaves();
        _storyPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (_waveNum > 0)
        {
            _counter += Time.deltaTime;
            if (_counter >= _spawnTime)
            {
                _counter = 0;
                SpawnWave();
            }
        }
    }
    public void StartWaves()
    {
        RefillWaves();
        _waveNum = 1;
        _displayText.SetMessage("WAVE 1");
        _storyPanel.SetActive(false);
    }
    void SpawnWave()
    {
        do //make it so it cant spawn in the same lane 2 times in a row
        {
            _chosenSpawnPointNum = Random.Range(0, _enemySpawnPoints.Count);

        } while (_chosenSpawnPointNum == _lastLaneSelected);
        _lastLaneSelected = _chosenSpawnPointNum;
        if (_waveNum == 1)
        {
            if (_wave1.Count == 0)
            {
                _waveNum = 2;
                Debug.Log("wave2 start");
                _displayText.SetMessage("WAVE 2");
                return;

            }
            _spawnTime = 9f;
            int _randomEnemyNum = Random.Range(0, _wave1.Count);
            Instantiate(_wave1[_randomEnemyNum], _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
            _wave1.RemoveAt(_randomEnemyNum);

        }
        else if (_waveNum == 2)
        {
            if (_wave2.Count == 0)
            {
                _waveNum = 3;
                Debug.Log("wave3 start");
                _displayText.SetMessage("WAVE 3");
                return;

            }
            _spawnTime = 6f;
            int _randomEnemyNum = Random.Range(0, _wave2.Count);
            Instantiate(_wave2[_randomEnemyNum], _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
            _wave2.RemoveAt(_randomEnemyNum);

        }
        else if (_waveNum == 3)
        {
            if (_wave3.Count == 0)
            {
                _waveNum = 4;
                Debug.Log("wave4 start");
                _displayText.SetMessage("WAVE 4");
                return;

            }
            _spawnTime = 3.5f;
            int _randomEnemyNum = Random.Range(0, _wave3.Count);
            GameObject m_vamp = Instantiate(_wave3[_randomEnemyNum], _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
            m_vamp.GetComponent<EnemyMovementScript>().SetSpeed(1);

            _wave3.RemoveAt(_randomEnemyNum);

        }
        else if (_waveNum == 4)
        {
            if (_wave4.Count == 0)
            {
                _waveNum = 5;
                Debug.Log("wave5 start");
                _displayText.SetMessage("WAVE 5");
                return;
            }
            _spawnTime = 1.5f;
            int _randomEnemyNum = Random.Range(0, _wave4.Count);
            GameObject m_vamp = Instantiate(_wave4[_randomEnemyNum], _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
            m_vamp.GetComponent<EnemyMovementScript>().SetSpeed(1.3f);
            _wave4.RemoveAt(_randomEnemyNum);

        }
        else if (_waveNum == 5)
        {
            //SPAWN LAST WAVE + DRACULA GIANT
            if (_wave5.Count == 0)
            {
                Debug.Log("DRACULA");
                _displayText.SetMessage("BOSS WAVE");
                GameObject m_dracula = Instantiate(_dracula, _enemySpawnPoints[3].position, Quaternion.identity);
                _draculaHealthbar.DraculaSpawned(); //make health bar appear
                _waveNum = 6; //so it doesnt keep spawning draculas
                return;
            }

            //spawn waves before dracula
            _spawnTime = 0.1f;
            int _randomEnemyNum = Random.Range(0, _wave5.Count);
            GameObject m_vamp = Instantiate(_wave5[_randomEnemyNum], _enemySpawnPoints[_chosenSpawnPointNum].position, Quaternion.identity);
            m_vamp.GetComponent<EnemyMovementScript>().SetSpeed(1f);
            _wave5.RemoveAt(_randomEnemyNum);
            if (_wave5.Count == 1)
            {
                 _spawnTime = 9f;
            }
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
    void RefillWaves()
    {
        _wave1 = new List<GameObject>() { _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy };
        _wave2 = new List<GameObject>() { _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _batEnemy };
        _wave3 = new List<GameObject>() { _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _tankEnemy, _tankEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy };
        _wave4 = new List<GameObject>() { _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy, _batEnemy };
        _wave5 = new List<GameObject>() { _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _tankEnemy, _basicEnemy, _basicEnemy, _basicEnemy, _basicEnemy };

    }

    public void RestartGame()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
        _draculaHealthbar.ResetDraculaBar(); //reset dracula bar before despawning dracula so it doesnt think you won the game

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Dracula"))
        {
            Destroy(item);
        }
        foreach (TowerHealthScript item in GameObject.FindObjectsOfType<TowerHealthScript>())
        {
            if (item.gameObject.name != "Fence")
            {
                item.DamageTower(1000);
            }
        }
        foreach (BloodShooterScript item in GameObject.FindObjectsOfType<BloodShooterScript>())
        {
            item.gameObject.GetComponent<TowerHealthScript>().DamageTower(1000);
        }
        foreach (BloodBagTower item in GameObject.FindObjectsOfType<BloodBagTower>())
        {
            item.gameObject.GetComponent<TowerHealthScript>().DamageTower(1000);
        }
        foreach (FangScript item in GameObject.FindObjectsOfType<FangScript>())
        {
            Destroy(item.gameObject);
        }
        foreach (GameObject fence in _fences)
        {
            fence.GetComponent<TowerHealthScript>().SetHealth(25);
            fence.gameObject.SetActive(true);
        }
        _waveNum = 0;
        _counter = 0;
        GameObject.FindObjectOfType<TowerSelectionScript>().ResetFangs(11);
        gameObject.GetComponent<HealthScript>().Reset();
        _displayText.SetMessage("");
        _restartButton.SetActive(false);
        Time.timeScale = 1;
        StartWaves();
    }
}
