using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBounce : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) //if the bat hits this it will change its y direction
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyMovementScript>().SwitchYDirection();
        }
    }

}
