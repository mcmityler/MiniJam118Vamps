using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraculaHealthBarScript : MonoBehaviour
{
    [SerializeField] Image _healthBarFill;
    [SerializeField] GameObject _draculaHealthBar;
    EnemyHealthScript _draculaHealthScript;
    [SerializeField] int _maxHealth = 30;
    bool _draculaSpawned = false;
    [SerializeField] DisplayTextScript _displayText;
    [SerializeField] private GameObject _restartButton;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Dracula") != null) //if dracula exists0
        {
            ShowHealthbar();
            _draculaHealthScript = GameObject.FindGameObjectWithTag("Dracula").GetComponent<EnemyHealthScript>(); //get health script reference
            int m_health = _draculaHealthScript.GetHealth();
            float m_fillAmount = (float)m_health / (float)_maxHealth;
            _healthBarFill.fillAmount = m_fillAmount;
        }
        else
        {
            HideHealthBar();
            if (_draculaSpawned) //you won the game and beat dracula
            {
                Debug.Log("End Game!");
                _draculaSpawned = false;
                _displayText.SetMessage("YOU WIN!! THANK YOU FOR PLAYING!! :) ");
                _restartButton.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
    public void DraculaSpawned(){
        _draculaSpawned = true;
    }
    public void ResetDraculaBar()
    {
        _draculaSpawned = false;
    }
    public void ShowHealthbar()
    {
        _draculaHealthBar.SetActive(true);

    }
    public void HideHealthBar()
    {
        _draculaHealthBar.SetActive(false);

    }
    void Awake()
    {
        HideHealthBar();
    }
}
