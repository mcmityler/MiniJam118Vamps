using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] int _vampireHealth = 3;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BloodBullet")
        {
            Destroy(col.gameObject);
            _vampireHealth--;
            if (_vampireHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
