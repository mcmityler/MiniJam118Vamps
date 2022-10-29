using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FangScript : MonoBehaviour
{
    int _fangValue = 0;
    void Awake()
    {
        if (FindObjectOfType<AudioManager>().GetSoundMuted() == false) //check games not muted
        {
            this.gameObject.GetComponent<AudioSource>().Play(); //play vampire death sound when this spawns
        }
    }
    void OnMouseEnter()
    {
        GameObject.Find("GameplayManager").GetComponent<TowerSelectionScript>().AddFangs(_fangValue);
        Destroy(this.gameObject);

    }
    public void SetFangValue(int m_value)
    {
        _fangValue = m_value;
    }
}
