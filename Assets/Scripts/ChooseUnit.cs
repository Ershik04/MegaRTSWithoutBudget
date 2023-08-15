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
    private MousePosition _unit;
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
        if (_gameUnit != null && _unit != null)
        {
            _unit.MoveUnit(_gameUnit);
        }
    }

    public void SaveUnit(GameUnit gameUnit)
    {
        MousePosition mousePosition;
        _gameUnit = gameUnit;
        mousePosition = _gameUnit.GetComponent<MousePosition>();
        _unit = mousePosition;
    }

    private void DisbandUnit()
    {
        if (_gameUnit != null)
        {
            _image.sprite = null;
            _label.text = "";
            _health.text = "";
            _description.text = "";
            Destroy(_gameUnit.gameObject);
            _gameUnit = null;
        }
    }
}
