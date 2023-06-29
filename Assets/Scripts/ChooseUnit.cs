using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseUnit : MonoBehaviour
{
    [SerializeField]
    private GameUnit _gameUnit;
    [SerializeField]
    private MousePosition _unit;
    [SerializeField]
    private Button _disbandButton;

    private void Start()
    {
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
            Destroy(_gameUnit.gameObject);
            _gameUnit = null;
        }
    }
}
