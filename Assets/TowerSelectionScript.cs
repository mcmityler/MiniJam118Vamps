using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _towerTypeList;
    private GameObject _selectedTower = null;

    public void SelectTower(int m_buttonPressed) //match button pressed with towers placement inside of the gameobject list
    {
        if(m_buttonPressed == -1){
            _selectedTower = null; //reset selected 
            return;
        }
        _selectedTower = _towerTypeList[m_buttonPressed];
    }
    public GameObject GetTower(){
        if(_selectedTower == null){
            return null;
        }
        return _selectedTower;
    }

}
