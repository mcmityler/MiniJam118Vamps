/*
* Creator : Tyler McMillan
* Description: Basic Vampire enemy script
*/
using UnityEngine;

public class VampireBasic : MonoBehaviour
{
    private float _moveSpeed = 1f; //how fast vampire moves
    [SerializeField] Vector3 _moveDirection = new Vector3(-1, 0, 0); //direction for the bullet to travel
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
    void Update(){
        this.gameObject.transform.position += (_moveDirection * Time.deltaTime * _moveSpeed);
    }
}
