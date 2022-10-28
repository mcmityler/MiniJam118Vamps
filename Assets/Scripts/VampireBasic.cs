/*
* Creator : Tyler McMillan
* Description: Basic Vampire enemy script
*/
using UnityEngine;

public class VampireBasic : MonoBehaviour
{

    [SerializeField] int _vampireHealth = 3;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BloodBullet"){
            Destroy(col.gameObject);
            _vampireHealth --;
            if(_vampireHealth <= 0){
                Destroy(this.gameObject);
            }
        }
    }
}
