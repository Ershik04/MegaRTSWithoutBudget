using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseUnit : MonoBehaviour
{
    [SerializeField]
    private GameUnit _gameUnit;
    [SerializeField]
    private Button _disbandButton;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _health;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private Image _image;

    public GameUnit ChoosedUnit => _gameUnit;

    private void Start()
    {
        _image = GameObject.FindGameObjectWithTag("UnitImage").GetComponent<Image>();
        _label = GameObject.FindGameObjectWithTag("UnitName").GetComponent<TMP_Text>();
        _health = GameObject.FindGameObjectWithTag("UnitHealth").GetComponent<TMP_Text>();
        _description = GameObject.FindGameObjectWithTag("UnitDescription").GetComponent<TMP_Text>();
        _disbandButton = GameObject.FindGameObjectWithTag("DisbandButton").GetComponent<Button>();
        _disbandButton.onClick.AddListener(DisbandUnit);
    }

    private void Update()
    {
/*        if (_gameUnit != null && _unit != null)
        {
            _unit.MoveUnit(_gameUnit);
        }*/
    }

    public void SaveUnit(GameUnit gameUnit)
    {
        _gameUnit = gameUnit;
    }

    public void DisbandUnit()
    {
        UnitsManager unitsManager = GetComponent<UnitsManager>();
        if (_gameUnit != null && unitsManager.FindUnitInOwn(_gameUnit))
        {
            GameUnit gameUnit = _gameUnit;
            _image.sprite = null;
            _label.text = "";
            _health.text = "";
            _description.text = "";
            Destroy(_gameUnit.gameObject);
            _gameUnit = null;
            unitsManager.DeleteUnitFromOwn(gameUnit);
        }
    }
}
