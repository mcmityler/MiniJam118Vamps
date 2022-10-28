using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int _health = 3;
    [SerializeField] TMP_Text _healthText;
    public void RemoveHealth(int m_decrementAmount){
        _health -= m_decrementAmount;
        if(_health < 0){
            _health = 0;
        }
        _healthText.text = _health.ToString();
    }
}
