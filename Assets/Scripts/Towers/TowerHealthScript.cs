using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthScript : MonoBehaviour
{

    private GameObject _slotPlacedIn;
    [SerializeField] private int _health = 100;

    public void SetSlot(GameObject m_slot)
    {
        _slotPlacedIn = m_slot;
    }
    public void DamageTower(int m_damageRecieved)
    {
        _health -= m_damageRecieved;
        if (_health <= 0)
        {
            _slotPlacedIn.GetComponent<TowerPlacementScript>().TowerDestoryed();
            Destroy(this.gameObject);
        }
    }
}
