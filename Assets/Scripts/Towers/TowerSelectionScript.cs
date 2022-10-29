using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSelectionScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _towerTypeList;
    private GameObject _selectedTower = null;
    [SerializeField] TMP_Text _fangAmountText;


    private int _amountOfFangs = 10;

    void Awake(){
        _fangAmountText.text = _amountOfFangs.ToString(); //set starting fang amount
    }
    public void SelectTower(int m_buttonPressed) //match button pressed with towers placement inside of the gameobject list
    {
        if(m_buttonPressed == -1){
            _selectedTower = null; //reset selected 
            return;
        }
        _selectedTower = _towerTypeList[m_buttonPressed];
        FindObjectOfType<AudioManager>().Play("ButtonClick");

    }
    public GameObject GetTower(){
        if(_selectedTower == null){
            return null;
        }
        return _selectedTower;
    }
    public void AddFangs(int m_fangs){
        _amountOfFangs += m_fangs;
        _fangAmountText.text = _amountOfFangs.ToString(); //update fang amount
    }

}
