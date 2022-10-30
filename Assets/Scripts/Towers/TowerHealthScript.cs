using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthScript : MonoBehaviour
{

    private GameObject _slotPlacedIn;
    [SerializeField] private int _health = 100;
    [SerializeField] private bool _isFence = false;

    public void SetSlot(GameObject m_slot)
    {
        _slotPlacedIn = m_slot;
    }
    public void DamageTower(int m_damageRecieved)
    {
        _health -= m_damageRecieved;
        if (_health <= 0)
        {
            if (_isFence == false) //set slot empty if its not a fence
            {
                _slotPlacedIn.GetComponent<TowerPlacementScript>().TowerDestoryed();
                Debug.Log("make tower destroy noise");
            }
            else
            {
                Debug.Log("make fence destroy sound");
                this.gameObject.SetActive(false); //set fence invisible instead of deleting for easy reset;
                return;
            }
            Destroy(this.gameObject);
            return;
        }
        Debug.Log("Make tower damage noise");
    }
    public void SetHealth(int m_healthAdded){
        _health = m_healthAdded;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyMovementScript>().StopMovement();
        }
    }
}
