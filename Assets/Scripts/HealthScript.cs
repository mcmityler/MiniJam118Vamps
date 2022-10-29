using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int _health = 3;
    [SerializeField] TMP_Text _healthText;
    DisplayTextScript _displayText;
   [SerializeField] CameraShake _cameraShake;
    void Awake()
    {
        _displayText = GameObject.Find("DisplayText").GetComponent<DisplayTextScript>();

    }
    public void RemoveHealth(int m_decrementAmount)
    {
        _health -= m_decrementAmount;
        if (_health <= 0)
        {
            _health = 0;
            GameOver();
            return;

        }
        StartCoroutine(_cameraShake.Shake(0.3f,0.3f)); //make camera shake whenever you take damage

        _healthText.text = _health.ToString();
        if (_health > 0)
        {
            _displayText.SetMessage("Took Damage: " + _health.ToString() + " health left.");
        }
    }
    void GameOver()
    {
        _displayText.SetMessage("Game Over!!");
        Time.timeScale = 0;
    }
}
