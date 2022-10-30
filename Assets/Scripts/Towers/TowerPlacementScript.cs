/*
* Creator : Tyler McMillan
* Description: Script that allows player to place towers
*/
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacementScript : MonoBehaviour
{

    [SerializeField] private string _towerSelected = "bloodShooter";

    [SerializeField] private Sprite _selectedSprite, _unselectedSprite;

    [SerializeField] GameObject _bloodShooterTower;
    private GameObject _selectedTowerType = null;

    [SerializeField] Transform _turretSpawnPoint;
    TowerSelectionScript _towerSelectionScript;
    [SerializeField] Color _selectedColour = Color.white;

    bool _highlighted = false;
    bool _towerPlaced = false;
    SettingScript _settingScript;
    DisplayTextScript _displayText;

    void Start()
    {
        _towerSelectionScript = GameObject.Find("GameplayManager").gameObject.GetComponent<TowerSelectionScript>();

        _settingScript = GameObject.Find("SettingsManager").GetComponent<SettingScript>();
        _displayText = GameObject.Find("DisplayText").GetComponent<DisplayTextScript>();

    }
    void OnMouseEnter()
    {
        HighlightSlot();

    }
    void OnMouseExit()
    {
        if (_highlighted == true)
        {
            UnhighlightSlot();
        }


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_highlighted && _towerPlaced == false) //make sure its highlighted, you havent already placed a turret there
            {
                PlaceTower();

            }
            if (_highlighted && _towerPlaced == true) //make sure its highlighted and you placed turret there already
            {
                Debug.Log("Upgrade Tower");

            }
        }


    }
    public void HighlightSlot()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = _selectedSprite;
        _highlighted = true;
        _selectedTowerType = _towerSelectionScript.GetTower();
        if (_selectedTowerType == null && _towerPlaced == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _selectedSprite;

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (_towerPlaced == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _selectedTowerType.GetComponent<SpriteRenderer>().sprite;

            this.gameObject.GetComponent<SpriteRenderer>().color = _selectedColour;
        }
        else if (_towerPlaced == true) //if you wanted to upgrade the towers 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _selectedSprite;

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

    }
    public void UnhighlightSlot()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = _unselectedSprite;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        _highlighted = false;

    }
    public void PlaceTower()
    {
        if (_settingScript.GetPaused() == false) //only allow to place towers if you arent paused (because you can click through panel for some reason)
        {
            if (_selectedTowerType == null) //what to do if no tower is selected
            {
                Debug.Log("no tower selected");
                FindObjectOfType<AudioManager>().Play("CantPlace");
                _displayText.SetMessage("No Tower Selected");

                return;
            }

            _highlighted = false;
            _towerPlaced = true;
            //Get Tower from tower selections cript and set to null
            GameObject m_tower = Instantiate(_selectedTowerType, _turretSpawnPoint.position, Quaternion.identity);
            m_tower.GetComponent<TowerHealthScript>().SetSlot(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _unselectedSprite;
            _towerSelectionScript.SelectTower(-1); //reset selection to null;
            FindObjectOfType<AudioManager>().Play("PlaceTower");

            if(_selectedTowerType.name == "BloodShooter"){
                _towerSelectionScript.RemoveFangs(5);
            }
            if(_selectedTowerType.name == "BloodBagBlocker"){
                _towerSelectionScript.RemoveFangs(12);
            }

        }
    }
    public void TowerDestoryed()
    {
        _towerPlaced = false;
    }
}