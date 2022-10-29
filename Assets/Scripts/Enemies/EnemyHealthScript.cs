using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] int _vampireHealth = 3;
    [SerializeField] int _fangValue = 1;
    [SerializeField] GameObject _fangPickup;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BloodBullet")
        {
            Destroy(col.gameObject);
            _vampireHealth--;
            if (_vampireHealth <= 0)
            {
                SpawnFangPickup();
                Destroy(this.gameObject);
            }
        }
    }
    void SpawnFangPickup()
    {
       GameObject m_fang =  Instantiate(_fangPickup, gameObject.transform.position, Quaternion.identity);
    m_fang.GetComponent<FangScript>().SetFangValue(_fangValue);
    }
}