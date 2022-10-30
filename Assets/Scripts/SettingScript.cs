using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    bool _paused = false;
    [SerializeField] GameObject _pauseMenuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
        {
            TogglePaused();
        }
    }
    public void TogglePaused()
    {
        _paused = !_paused; //set to opposite
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        if (_paused) //if true open menu and stop time
        {
            Time.timeScale = 0f;
            _pauseMenuPanel.SetActive(true);

        }
         if (!_paused) //if false close menu and resume time
        {
            Time.timeScale = 1f;
            _pauseMenuPanel.SetActive(false);


        }
    }
    public void QuitGame(){
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        if(Application.platform != RuntimePlatform.WebGLPlayer){
        Application.Quit();
        }
            print("Quit the game");

    }
    public bool GetPaused(){
        return _paused;
    }
}
