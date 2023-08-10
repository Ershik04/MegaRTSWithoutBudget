using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    [SerializeField]
    private bool _selected;
    [SerializeField]
    private int _number;
    [SerializeField]
    private GameObject _unitMenu;

    public bool Selected => _selected;
    public int Number => _number;

    public void SelectUnit()
    {
        _selected = true;
    }

    public void SetUnitMenu(GameObject unitMenu)
    {
        _unitMenu = unitMenu;
    }
}
