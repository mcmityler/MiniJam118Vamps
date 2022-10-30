using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectionScript : MonoBehaviour
{
    [SerializeField] List<GameObject> _towerTypeList;
    private GameObject _selectedTower = null;
    [SerializeField] TMP_Text _fangAmountText;
    AudioManager _audioManager;
    [SerializeField] List<GameObject> _towerButtons;
    int lastButtonNum = -1;

    [SerializeField] DisplayTextScript _displayTextScript;
    [SerializeField] private int _amountOfFangs = 100;

    void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _fangAmountText.text = _amountOfFangs.ToString(); //set starting fang amount
        EvaluatePrices();

    }
    public void SelectTower(int m_buttonPressed) //match button pressed with towers placement inside of the gameobject list
    {

        if (m_buttonPressed == -1)
        {
            _selectedTower = null; //reset selected 
            _towerButtons[lastButtonNum].GetComponent<Image>().color = Color.white;
            //make sure that the normal colour is solid to show clear
            Button b2 = _towerButtons[lastButtonNum].GetComponent<Button>();
            ColorBlock cb2 = b2.colors;
            cb2.normalColor = Color.clear;
            b2.colors = cb2;
            return;
        }
        if (_towerButtons[m_buttonPressed].GetComponent<Image>().color != Color.red)
        {
            if (m_buttonPressed == lastButtonNum && _towerButtons[m_buttonPressed].GetComponent<Image>().color == Color.green) //same tower pressed twice so unselect it & make sure it was selected / green
            {
                _towerButtons[m_buttonPressed].GetComponent<Image>().color = Color.white;

                //make sure that the normal colour is clear
                Button b = _towerButtons[m_buttonPressed].GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.clear;
                b.colors = cb;

                _selectedTower = null;
                lastButtonNum = -1;

            }
            else //its a new number
            {
                _selectedTower = _towerTypeList[m_buttonPressed];
                if (lastButtonNum != -1)
                {
                    _towerButtons[lastButtonNum].GetComponent<Image>().color = Color.white;
                    //make sure that the normal colour is solid to show clear
                    Button b2 = _towerButtons[m_buttonPressed].GetComponent<Button>();
                    ColorBlock cb2 = b2.colors;
                    cb2.normalColor = Color.clear;
                    b2.colors = cb2;
                }
                _towerButtons[m_buttonPressed].GetComponent<Image>().color = Color.green;
                //make sure that the normal colour is solid to show green
                Button b = _towerButtons[m_buttonPressed].GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.white;
                b.colors = cb;

                lastButtonNum = m_buttonPressed;

            }
            FindObjectOfType<AudioManager>().Play("ButtonClick");
        }
        else //button is red and unselectable
        {
            Debug.Log("Cant Afford");
            _displayTextScript.SetMessage("Can't Afford Tower");
            FindObjectOfType<AudioManager>().Play("CantPlace");
        }




    }
    public GameObject GetTower()
    {
        if (_selectedTower == null)
        {
            return null;
        }
        return _selectedTower;
    }
    void EvaluatePrices()
    {
        if (_amountOfFangs < 5)
        {
            // ************ BLOOD SHOOTER *************************
            _towerButtons[0].GetComponent<Image>().color = Color.red;
            Button b = _towerButtons[0].GetComponent<Button>(); //make red visible even when not selected
            ColorBlock cb = b.colors;
            cb.normalColor = Color.white;
            b.colors = cb;

            // ************ OTHER TOWERS*************************

        }
        else if (_amountOfFangs >= 5)
        {
            // ************ BLOOD SHOOTER *************************
            if (_towerButtons[0].GetComponent<Image>().color != Color.green) //only update price colour if its not selected
            {
                _towerButtons[0].GetComponent<Image>().color = Color.white;
                //make sure that the normal colour is clear
                Button b = _towerButtons[0].GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.clear;
                b.colors = cb;
            }
            // ************ OTHER TOWERS*************************

        }
        if (_amountOfFangs < 12)
        {
            // ************ BLOOD BLOCKER *************************

            _towerButtons[1].GetComponent<Image>().color = Color.red;
            Button b = _towerButtons[1].GetComponent<Button>(); //make red visible even when not selected
            ColorBlock cb = b.colors;
            cb.normalColor = Color.white;
            b.colors = cb;


        }
        else if (_amountOfFangs >= 12)
        {
            // ************ BLOOD BLOCKER *************************
            if (_towerButtons[1].GetComponent<Image>().color != Color.green) //only update price colour if its not selected
            {
                _towerButtons[1].GetComponent<Image>().color = Color.white;
                //make sure that the normal colour is clear
                Button b = _towerButtons[1].GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.clear;
                b.colors = cb;
            }
            // ************ OTHER TOWERS*************************

        }
    }


    public void AddFangs(int m_fangs)
    {
        _audioManager.Play("CollectFang");
        _amountOfFangs += m_fangs;
        _fangAmountText.text = _amountOfFangs.ToString(); //update fang amount
        EvaluatePrices();
    }
    public void RemoveFangs(int m_fangs)
    {
        _amountOfFangs -= m_fangs;
        _fangAmountText.text = _amountOfFangs.ToString(); //update fang amount
        EvaluatePrices();
        _selectedTower = null; //purchased tower so unselect it
        lastButtonNum = -1; //reset last button pressed too because you placed and used it

    }
    public void ResetFangs(int m_fangs)
    {
        _amountOfFangs = m_fangs;
        _fangAmountText.text = _amountOfFangs.ToString(); //update fang amount
        EvaluatePrices();
    }

}
