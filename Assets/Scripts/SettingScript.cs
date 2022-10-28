using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown("escape"))
        {
            print("escape was pressed, quit the game");
            Application.Quit();
        }
    }
}
