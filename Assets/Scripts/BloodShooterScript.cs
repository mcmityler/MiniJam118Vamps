/*
* Creator : Tyler McMillan
* Description: script that controls basic blood shooter
*/
using UnityEngine;

public class BloodShooterScript : MonoBehaviour
{
    [SerializeField] GameObject _bloodBullet;

    [SerializeField] Transform _bulletSpawn;


    [SerializeField] float _timebetweenBullets = 2f;
    [SerializeField] float _moveSpeed = 2f;

    private float _bulletCounter = 2f;

    void Update()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        if (_bulletCounter >= _timebetweenBullets)
        {
            _bulletCounter = 0;
            Debug.Log("shoot bullet out");
            GameObject m_bullet = Instantiate(_bloodBullet, _bulletSpawn.position, Quaternion.identity);
            m_bullet.GetComponent<BloodBulletScript>().SetSpeed(_moveSpeed);
        }
        _bulletCounter += Time.deltaTime;
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyMovementScript>().StopMovement();
        }
    }
    
}
