using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    [SerializeField] HealthScript _healthScript;
    [SerializeField] int _damageAmount = 1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            _healthScript.RemoveHealth(_damageAmount);
            Destroy(col.gameObject);

        }
        if (col.gameObject.tag == "Dracula")
        {
            _healthScript.RemoveHealth(3);
            //Destroy(col.gameObject);
        }
    }
}
