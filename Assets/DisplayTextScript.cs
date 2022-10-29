using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTextScript : MonoBehaviour
{
    string message = "";

    public void SetMessage(string m_message){
        message = m_message;
        this.GetComponent<TMP_Text>().text = message;
        this.gameObject.GetComponent<Animator>().SetTrigger("DisplayText");
    }
}
