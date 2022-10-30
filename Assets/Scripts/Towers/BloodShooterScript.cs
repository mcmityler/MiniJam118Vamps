/*
* Creator : Tyler McMillan
* Description: script that controls basic blood shooter
*/
using UnityEngine;

public class BloodShooterScript : MonoBehaviour
{
    [SerializeField] GameObject _bloodBullet;

    [SerializeField] Transform _bulletSpawn;


    [SerializeField] float _timebetweenBullets = 2f; //how often to fire bullets
    [SerializeField] float _moveSpeed = 2f; //how fast the bullet travels

    private float _bulletCounter = 2f; //counter to count when to fire next bullet

    void Update()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        if (_bulletCounter >= _timebetweenBullets)
        {
            _bulletCounter = 0;
            GameObject m_bullet = Instantiate(_bloodBullet, _bulletSpawn.position, Quaternion.identity);
            m_bullet.GetComponent<BloodBulletScript>().SetSpeed(_moveSpeed);

        }
        _bulletCounter += Time.deltaTime;
    }
    
    
}
