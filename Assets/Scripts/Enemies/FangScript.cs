using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FangScript : MonoBehaviour
{
    int _fangValue = 0;
    void OnMouseEnter()
    {
        GameObject.Find("GameplayManager").GetComponent<TowerSelectionScript>().AddFangs(_fangValue);
        Destroy(this.gameObject);

    }
    public void SetFangValue(int m_value){
        _fangValue = m_value;
    }
}
