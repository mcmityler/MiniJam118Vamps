using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f; //how fast vampire moves
    [SerializeField] Vector3 _moveDirection = new Vector3(-1, 0, 0); //direction for the bullet to travel
    bool _stopMovement = false;
    [SerializeField] int _damageAmount = 1;
    [SerializeField] float _TimeToAttack = 0.1f; //every 0.1 seconds of being within tower range inflict _damageAmount ^^ hp of damage to the tower
    float _attackCounter = 0;
    bool _inTowerRange = false;
    List<GameObject> _towersInRange = new List<GameObject>();
    [SerializeField] Animator _vampireAnimator;
    void Update()
    {
        if (_stopMovement == false)
        {
            this.gameObject.transform.position += (_moveDirection * Time.deltaTime * _moveSpeed);

        }
        if (_inTowerRange)
        {
            _attackCounter += Time.deltaTime;
            if (_attackCounter >= _TimeToAttack)
            {
                _attackCounter = 0;
                List<GameObject> m_towerInRange = new List<GameObject>(_towersInRange);
                foreach (var _tower in m_towerInRange)
                {
                    _tower.GetComponent<TowerHealthScript>().DamageTower(_damageAmount);
                }
                if (_vampireAnimator != null)
                {
                    _vampireAnimator.SetTrigger("Attack");

                }

            }
        }
        if (_towersInRange.Count == 0)
        {
            _attackCounter = 0;
            _inTowerRange = false;
            ResumeMovement();
        }
        else
        {
            StopMovement();
        }
    }
    public void SetSpeed(float m_speed)
    {
        _moveSpeed = m_speed;
    }
    public void SwitchYDirection() //switch y direction (used for bat enemy)
    {
        _moveDirection = new Vector3(_moveDirection.x, -_moveDirection.y, _moveDirection.z);
    }
    public void StopMovement()
    {
        _stopMovement = true;
    }
    public void ResumeMovement()
    {
        _stopMovement = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tower")
        {
            _towersInRange.Add(col.gameObject);
            _inTowerRange = true;

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tower")
        {
            _towersInRange.Remove(col.gameObject);
        }
    }
}
