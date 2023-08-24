using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitView : MonoBehaviour
{
    [SerializeField]
    private UnitsData _data;
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _health;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private ChooseUnit _player;

    public UnitsData UnitData => _data;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChooseUnit>();
        _image = GameObject.FindGameObjectWithTag("UnitImage").GetComponent<Image>();
        _label = GameObject.FindGameObjectWithTag("UnitName").GetComponent<TMP_Text>();
        _health = GameObject.FindGameObjectWithTag("UnitHealth").GetComponent<TMP_Text>();
        _description = GameObject.FindGameObjectWithTag("UnitDescription").GetComponent<TMP_Text>();
    }

    public void Initialize(UnitsData unitsData)
    {
        _data = unitsData;
        _image.sprite = _data.UnitImage;
        _label.text = _data.UnitName;
        _health.text = _data.UnitHealth.ToString() + " Helath";
        _description.text = _data.UnitDescription;
    }

    private void OnMouseDown()
    {
        GameUnit gameUnit;
        Initialize(_data);
        TryGetComponent<GameUnit>(out gameUnit);
        gameUnit.SelectUnit();
        _player.SaveUnit(gameUnit);
    }
}
