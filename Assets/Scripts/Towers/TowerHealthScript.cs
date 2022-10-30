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
                FindObjectOfType<AudioManager>().Play("TowerDead");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("FenceDead");

                this.gameObject.SetActive(false); //set fence invisible instead of deleting for easy reset;
                return;
            }
            Destroy(this.gameObject);
            return;
        }
        if (_isFence == false)//make damage sound depending on whats being hit
        {
            FindObjectOfType<AudioManager>().Play("TowerDamage");

        }else{
            FindObjectOfType<AudioManager>().Play("FenceDamage");
        }
        Debug.Log("Make tower damage noise");
    }
    public void SetHealth(int m_healthAdded)
    {
        _health = m_healthAdded;
    }
}
